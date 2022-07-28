using System;
using System.Drawing;
using System.Windows.Forms;

namespace Train
{
    partial class MarkControl : UserControl
    {
        public MarkControl()
        {
            InitializeComponent();
        }

        public MarkControl(ImageMark mark)
        {
            InitializeComponent();
            this.Mark = mark;
            this.UpdateState();
        }

        public event EventHandler DeleteMark;

        public ImageMark Mark { get; private set; }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.Height != tblInfo.Height + 1)
            {
                this.Height = tblInfo.Height + 1;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawLine(Pens.Gray, 0, this.Height - 1, this.Width - 1, this.Height - 1);
        }

        public void UpdateState()
        {
            int? color = this.Mark?.ClassName?.Color;

            if (color.HasValue)
            {
                pnlColor.BackColor = Color.FromArgb(color.Value);
            }
            else
            {
                pnlColor.BackColor = this.BackColor;
            }

            lbText.Text = $"{this.Mark?.Width:0.00}x{this.Mark?.Height:0.00}";
        }

        void ControlMouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        void ControlMouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        void MarkControl_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();

            this.BackColor = SystemColors.ControlLight;
        }

        void MarkControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Delete)
            {
                DeleteMark?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
