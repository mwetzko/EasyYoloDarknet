using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Train
{
    partial class ImageControl : UserControl
    {
        List<ImageMark> mMarks;

        public ImageControl()
        {
            InitializeComponent();
        }

        public ImageControl(string image, ImageMark[] marks)
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

            mMarks = new List<ImageMark>();

            if (marks != null)
            {
                mMarks.AddRange(marks);
            }

            foreach (var item in new Control[] { pbImage, btnDelete })
            {
                item.GotFocus += OnFocusControl;
            }
        }

        public event EventHandler DeleteImage;
        public event EventHandler UnsavedChanges;
        public event EventHandler Selected;
        public string ImageName { get; private set; }
        public Image Image => pbImage.Image;
        public IEnumerable<ImageMark> Marks => mMarks;

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

        void EnsureUnsavedChanges()
        {
            UnsavedChanges?.Invoke(this, EventArgs.Empty);
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

        public void AddImageMark(ClassName cn, RectangleF rect)
        {
            // rect as relative center point and relative width / height as used by Yolo/Darknet
            var m = new ImageMark() { ClassId = cn.ID, CenterX = rect.X, CenterY = rect.Y, Width = rect.Width, Height = rect.Height, ClassName = cn };

            ProjectState.AddMark(m);

            mMarks.Add(m);

            EnsureUnsavedChanges();
        }
    }
}
