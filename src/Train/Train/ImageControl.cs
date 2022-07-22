using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Train
{
    partial class ImageControl : UserControl
    {
        public ImageControl()
        {
            InitializeComponent();
        }

        public ImageControl(string image)
        {
            InitializeComponent();

            if (File.Exists(image))
            {
                try
                {
                    pbImage.Image = Bitmap.FromFile(image);
                    this.ImageName = Path.GetFileName(image);
                }
                catch (Exception)
                {
                    // nothing
                }
            }

            foreach (var item in new Control[] { pbImage, btnDelete })
            {
                item.GotFocus += OnFocusControl;
            }
        }

        public event EventHandler DeleteImage;
        public event EventHandler Selected;
        public string ImageName { get; private set; }
        public Image Image => pbImage.Image;

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

        void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteImage?.Invoke(this, EventArgs.Empty);
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

        void pbImage_Click(object sender, EventArgs e)
        {
            this.Select();
        }
    }
}
