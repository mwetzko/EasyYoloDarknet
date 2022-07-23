using System;
using System.Drawing;
using System.Windows.Forms;

namespace Train
{
    public partial class ImageEditor : UserControl
    {
        Image mImage;
        float mScale = 1.0f;
        PointF mMouseLocation;
        PointF mImagePos;
        PointF? mMoveImage;
        float mImageWidth;
        float mImageHeight;

        public ImageEditor()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        public Image Image
        {
            get
            {
                return mImage;
            }
            set
            {
                mImage = value;

                if (mImage != null)
                {
                    mImagePos.X = (this.Width / 2f) - (mImageWidth / 2f);
                    mImagePos.Y = (this.Height / 2f) - (mImageHeight / 2f);

                    RevalidateImage();
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta < 0)
            {
                mScale -= 0.2f;

                if (mScale < 0.2f)
                {
                    mScale = 0.2f;
                }
            }
            else
            {
                mScale += 0.2f;

                if (mScale > 10f)
                {
                    mScale = 10f;
                }
            }

            if (this.Image != null)
            {
                RevalidateImage();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Right)
            {
                mMoveImage = mImagePos;
                mMouseLocation = e.Location;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            mMoveImage = null;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            mMoveImage = null;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (mMoveImage.HasValue && this.Image != null)
            {
                mImagePos.X = mMoveImage.Value.X + (e.X - mMouseLocation.X);
                mImagePos.Y = mMoveImage.Value.Y + (e.Y - mMouseLocation.Y);

                RevalidateImage();
            }
        }

        void RevalidateImage()
        {
            mImageWidth = (float)this.Image.Width * mScale;
            mImageHeight = (float)this.Image.Height * mScale;

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Image != null)
            {
                e.Graphics.DrawImage(this.Image, mImagePos.X, mImagePos.Y, mImageWidth, mImageHeight);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.Image != null)
            {
                RevalidateImage();

                this.Invalidate();
            }
        }
    }
}
