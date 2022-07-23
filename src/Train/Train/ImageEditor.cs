using System;
using System.Drawing;
using System.Windows.Forms;

namespace Train
{
    public partial class ImageEditor : UserControl
    {
        Image mImage;
        int mScale = 100;
        int mScaleMultiplier = 1;
        PointF mMouseLocation;
        PointF mImagePos;
        SizeF mImageSize;
        bool mFromCenter;

        public ImageEditor()
        {
            InitializeComponent();

            bufferPanel.MouseWheel += bufferPanel_MouseWheel;

            this.DoubleBuffered = true;

            UpdateScaleText();
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
                    CalcImageSize();
                    CenterImage();

                    bufferPanel.Invalidate();
                }
            }
        }

        void UpdateScaleText()
        {
            lbScale.Text = $"{mScale} %";
        }

        void CenterImage()
        {
            mFromCenter = true;
            mImagePos.X = (bufferPanel.Width / 2f) - (mImageSize.Width / 2f);
            mImagePos.Y = (bufferPanel.Height / 2f) - (mImageSize.Height / 2f);
        }

        void CalcImageSize()
        {
            var s = mScale / 100f;

            mImageSize.Width = this.Image.Width * s;
            mImageSize.Height = this.Image.Height * s;
        }

        void CalcRelativeImagePos(SizeF formerImageSize)
        {
            if (mMouseLocation.X < mImagePos.X || mMouseLocation.X > (mImagePos.X + formerImageSize.Width))
            {
                mImagePos.X = mImagePos.X + (formerImageSize.Width / 2) - (mImageSize.Width / 2);
            }
            else
            {
                mImagePos.X = mMouseLocation.X - (((mMouseLocation.X - mImagePos.X) / formerImageSize.Width) * mImageSize.Width);
            }

            if (mMouseLocation.Y < mImagePos.Y || mMouseLocation.Y > (mImagePos.Y + formerImageSize.Height))
            {
                mImagePos.Y = mImagePos.Y + (formerImageSize.Height / 2) - (mImageSize.Height / 2);
            }
            else
            {
                mImagePos.Y = mMouseLocation.Y - (((mMouseLocation.Y - mImagePos.Y) / formerImageSize.Height) * mImageSize.Height);
            }
        }

        void bufferPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this.Image != null)
            {
                e.Graphics.DrawImage(this.Image, mImagePos.X, mImagePos.Y, mImageSize.Width, mImageSize.Height);
            }
        }

        void bufferPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mMouseLocation = e.Location;
        }

        void bufferPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mMouseLocation = e.Location;
        }

        void bufferPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.Image != null)
            {
                mImagePos.X += (e.X - mMouseLocation.X);
                mImagePos.Y += (e.Y - mMouseLocation.Y);

                bufferPanel.Invalidate();
            }

            mMouseLocation = e.Location;
        }

        void bufferPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            mFromCenter = false;

            if (e.Delta < 0)
            {
                if (mScaleMultiplier > 1)
                {
                    mScaleMultiplier -= 1;

                    mScale -= (20 * mScaleMultiplier);
                }
                else if (mScale > 20)
                {
                    mScale -= 20;
                }
            }
            else
            {
                if (mScale < 100)
                {
                    mScale += 20;
                }
                else if (mScaleMultiplier < 10)
                {
                    mScale += (20 * mScaleMultiplier);

                    mScaleMultiplier += 1;
                }
            }

            UpdateScaleText();

            if (this.Image != null)
            {
                SizeF sz = mImageSize;

                CalcImageSize();
                CalcRelativeImagePos(sz);

                bufferPanel.Invalidate();
            }
        }

        void bufferPanel_Resize(object sender, EventArgs e)
        {
            if (mFromCenter)
            {
                CenterImage();
            }
            else
            {
                CalcRelativeImagePos(mImageSize);
            }

            bufferPanel.Invalidate();
        }
    }
}
