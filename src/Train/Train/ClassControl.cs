﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Train
{
    partial class ClassControl : UserControl
    {
        string mTempClassName;
        ClassName mClassName;

        public ClassControl()
        {
            InitializeComponent();
        }

        public ClassControl(ClassName cn)
        {
            InitializeComponent();

            mClassName = cn;
            btnColorPicker.BackColor = Color.FromArgb(cn.Color);
            colorPicker.Color = btnColorPicker.BackColor;
            txtClassname.Text = cn.Name;

            EnsureReadonlyState();

            foreach (var item in new Control[] { txtClassname, btnRename, btnOk, btnCancel, btnDelete, btnColorPicker })
            {
                item.GotFocus += OnFocusControl;
            }
        }

        public event EventHandler<BeforeRenameEventArgs> BeforeRename;
        public event EventHandler DeleteClass;
        public event EventHandler UnsavedChanges;
        public event EventHandler Selected;
        public bool Editing => !txtClassname.ReadOnly;
        public ClassName ClassName => mClassName;
        public string CurrentClassName => this.Editing ? mTempClassName : txtClassname.Text;

        void btnRename_Click(object sender, EventArgs e)
        {
            mTempClassName = txtClassname.Text;
            txtClassname.ReadOnly = false;
            btnRename.Visible = false;
            btnOk.Visible = true;
            btnCancel.Visible = true;
            btnDelete.Visible = true;
        }

        void btnColorPicker_Click(object sender, EventArgs e)
        {
            if (colorPicker.ShowDialog() == DialogResult.OK && colorPicker.Color != btnColorPicker.BackColor)
            {
                btnColorPicker.BackColor = colorPicker.Color;
                mClassName.Color = colorPicker.Color.ToArgb();
                EnsureUnsavedChanges();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.Height != tblActions.Height + 1)
            {
                this.Height = tblActions.Height + 1;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

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

            mClassName.Name = args.Name;

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
            btnDelete.Visible = false;
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

        void rbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelect.Checked)
            {
                Selected?.Invoke(this, EventArgs.Empty);
            }
        }

        void OnFocusControl(object sender, EventArgs e)
        {
            this.Select();
        }

        public new void Select()
        {
            rbSelect.Checked = true;
        }

        public void Deselect()
        {
            rbSelect.Checked = false;
        }
    }
}
