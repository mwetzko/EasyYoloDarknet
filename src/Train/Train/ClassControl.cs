using System;
using System.Drawing;
using System.Windows.Forms;

namespace Train
{
    partial class ClassControl : UserControl
    {
        string mTempClassName;

        public ClassControl()
        {
            InitializeComponent();
        }

        public ClassControl(string name, int color)
        {
            InitializeComponent();

            btnColorPicker.BackColor = Color.FromArgb(color);
            colorPicker.Color = btnColorPicker.BackColor;
            txtClassname.Text = name;

            EnsureReadonlyState();
        }

        public event EventHandler<BeforeRenameEventArgs> BeforeRename;
        public event EventHandler DeleteClass;
        public event EventHandler UnsavedChanges;
        public bool Editing => !txtClassname.ReadOnly;
        public string ClassName => this.Editing ? mTempClassName : txtClassname.Text;
        public int ClassColor => btnColorPicker.BackColor.ToArgb();

        void btnRename_Click(object sender, EventArgs e)
        {
            mTempClassName = txtClassname.Text;
            txtClassname.ReadOnly = false;
            btnRename.Visible = false;
            btnOk.Visible = true;
            btnCancel.Visible = true;
        }

        void btnColorPicker_Click(object sender, EventArgs e)
        {
            if (colorPicker.ShowDialog() == DialogResult.OK && colorPicker.Color != btnColorPicker.BackColor)
            {
                btnColorPicker.BackColor = colorPicker.Color;
                EnsureUnsavedChanges();
            }
        }

        void ClassControl_Resize(object sender, EventArgs e)
        {
            if (this.Height != tablePanel.Height + 1)
            {
                this.Height = tablePanel.Height + 1;
            }
        }

        void ClassControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Gray, 0, this.Height - 1, this.Width - 1, this.Height - 1);
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            var args = new BeforeRenameEventArgs() { Name = txtClassname.Text };

            BeforeRename?.Invoke(this, args);

            if (args.Cancel)
            {
                return;
            }

            EnsureReadonlyState();
            EnsureUnsavedChanges();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }

        public void CancelChanges()
        {
            if (this.Editing)
            {
                txtClassname.Text = mTempClassName;
                EnsureReadonlyState();
            }
        }

        void EnsureReadonlyState()
        {
            txtClassname.ReadOnly = true;
            btnRename.Visible = true;
            btnOk.Visible = false;
            btnCancel.Visible = false;
        }

        void EnsureUnsavedChanges()
        {
            UnsavedChanges?.Invoke(this, EventArgs.Empty);
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClass?.Invoke(this, EventArgs.Empty);
        }

        void txtClassname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(btnOk, EventArgs.Empty);
            }
        }
    }
}
