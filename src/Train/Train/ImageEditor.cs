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
        Point mMouseLocation;
        Rectangle mImageRect;
        bool mFromCenter;
        Rectangle mSelection;

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

                if (this.HasImage)
                {
                    CalcImageSize();
                    CenterImage();

                    bufferPanel.Invalidate();
                }
            }
        }

        public bool HasImage
        {
            get
            {
                return mImage != null;
            }
        }

        void UpdateScaleText()
        {
            lbScale.Text = $"{mScale} %";
        }

        void CenterImage()
        {
            mFromCenter = true;

            mImageRect.X = (int)((bufferPanel.Width / 2f) - (mImageRect.Width / 2f));
            mImageRect.Y = (int)((bufferPanel.Height / 2f) - (mImageRect.Height / 2f));
        }

        void CalcImageSize()
        {
            var s = mScale / 100f;

            mImageRect.Width = (int)(this.Image.Width * s);
            mImageRect.Height = (int)(this.Image.Height * s);
        }

        void CalcRelativeImagePos(Size formerImageSize)
        {
            if (mImageRect.Contains(mMouseLocation))
            {
                mImageRect.X = mMouseLocation.X - (int)(((mMouseLocation.X - mImageRect.X) / (float)formerImageSize.Width) * mImageRect.Width);
                mImageRect.Y = mMouseLocation.Y - (int)(((mMouseLocation.Y - mImageRect.Y) / (float)formerImageSize.Height) * mImageRect.Height);
            }
            else
            {
                mImageRect.X = mImageRect.X + (formerImageSize.Width / 2) - (mImageRect.Width / 2);
                mImageRect.Y = mImageRect.Y + (formerImageSize.Height / 2) - (mImageRect.Height / 2);
            }
        }

        void bufferPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this.HasImage)
            {
                e.Graphics.DrawImage(this.Image, mImageRect);
            }

            if (mSelection.Width != 0 && mSelection.Height != 0)
            {
                Rectangle rect = new Rectangle();

                if (mSelection.Width > 0)
                {
                    rect.X = mSelection.X;
                    rect.Width = mSelection.Width;
                }
                else
                {
                    rect.X = mSelection.X + mSelection.Width;
                    rect.Width = -mSelection.Width;
                }

                if (mSelection.Height > 0)
                {
                    rect.Y = mSelection.Y;
                    rect.Height = mSelection.Height;
                }
                else
                {
                    rect.Y = mSelection.Y + mSelection.Height;
                    rect.Height = -mSelection.Height;
                }

                rect = Rectangle.Intersect(mImageRect, rect);

                ControlPaint.DrawFocusRectangle(e.Graphics, rect);
            }
        }

        void bufferPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mMouseLocation = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                mSelection = new Rectangle(mMouseLocation, new Size(0, 0));
            }
        }

        void bufferPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mSelection.Width = 0;
                mSelection.Height = 0;

                bufferPanel.Invalidate();
            }

            mMouseLocation = e.Location;
        }

        void bufferPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mSelection.Width = e.X - mSelection.Location.X;
                mSelection.Height = e.Y - mSelection.Location.Y;

                bufferPanel.Invalidate();
            }
            else if (e.Button == MouseButtons.Right && this.HasImage)
            {
                mImageRect.X += (e.X - mMouseLocation.X);
                mImageRect.Y += (e.Y - mMouseLocation.Y);

                bufferPanel.Invalidate();
            }

            mMouseLocation = e.Location;
        }

        void bufferPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.HasImage)
            {
                if (e.Button == MouseButtons.None)
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

                    Size sz = mImageRect.Size;

                    CalcImageSize();
                    CalcRelativeImagePos(sz);

                    bufferPanel.Invalidate();
                }
            }
        }

        void bufferPanel_Resize(object sender, EventArgs e)
        {
            if (this.HasImage)
            {
                if (mFromCenter)
                {
                    CenterImage();
                }
                else
                {
                    CalcRelativeImagePos(mImageRect.Size);
                }

                bufferPanel.Invalidate();
            }
        }
    }
}
