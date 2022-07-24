using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Train
{
    partial class ImageEditor : UserControl
    {
        int mScale = 100;
        int mScaleMultiplier = 1;
        Point mMouseLocation;
        Rectangle mImageRect;
        bool mFromCenter;
        Rectangle mSelection;
        Font mScaleFont;

        public ImageEditor()
        {
            InitializeComponent();

            bufferPanel.MouseWheel += bufferPanel_MouseWheel;

            this.DoubleBuffered = true;

            UpdateScaleInfo();
        }

        public event EventHandler<GetImageClassNameArgs> GetImageClassName;

        ImageControl mImageControl;

        public ImageControl ImageControl
        {
            get
            {
                return mImageControl;
            }
            set
            {
                mImageControl = value;

                if (this.HasImage)
                {
                    CalcImageSize();
                    CenterImage();

                    bufferPanel.Invalidate();
                }
            }
        }

        Image Image => mImageControl?.Image;

        IEnumerable<ImageMark> Marks => mImageControl?.Marks;

        bool HasImage => this.Image != null;

        void UpdateScaleInfo()
        {
            mScaleFont = new Font(this.Font.FontFamily, 8 * (mScale / 100f));

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

                foreach (var item in this.Marks)
                {
                    var c = Color.FromArgb(item.ClassName.Color);

                    float w = mImageRect.Width * item.Width;
                    float h = mImageRect.Height * item.Height;
                    float x = mImageRect.X + ((mImageRect.Width * item.CenterX) - (w / 2));
                    float y = mImageRect.Y + ((mImageRect.Height * item.CenterY) - (h / 2));

                    using (Brush b = new SolidBrush(c))
                    {
                        e.Graphics.DrawString(item.ClassName.Name, mScaleFont, b, x, y);
                    }

                    using (Pen p = new Pen(c))
                    {
                        e.Graphics.DrawRectangle(p, x, y, w, h);
                    }
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
        }

        void bufferPanel_MouseDown(object sender, MouseEventArgs e)
        {
            bufferPanel.Focus();

            mMouseLocation = e.Location;

            if (this.HasImage)
            {
                if (e.Button == MouseButtons.Left)
                {
                    mSelection = new Rectangle(mMouseLocation, new Size(0, 0));
                }
            }
        }

        void bufferPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (bufferPanel.Focused && this.HasImage)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (mSelection.Width > 0 && mSelection.Height > 0)
                    {
                        GetImageClassNameArgs args = new GetImageClassNameArgs();

                        GetImageClassName?.Invoke(this, args);

                        if (args.ClassName != null)
                        {
                            float w = (float)mSelection.Width / (float)mImageRect.Width;
                            float h = (float)mSelection.Height / (float)mImageRect.Height;
                            float x = ((mSelection.X - mImageRect.X) + (mSelection.Width / 2f)) / (float)mImageRect.Width;
                            float y = ((mSelection.Y - mImageRect.Y) + (mSelection.Height / 2f)) / (float)mImageRect.Height;

                            this.ImageControl.AddImageMark(args.ClassName, new RectangleF(x, y, w, h));
                        }
                    }

                    mSelection.Width = 0;
                    mSelection.Height = 0;

                    bufferPanel.Invalidate();
                }
            }

            mMouseLocation = e.Location;
        }

        void bufferPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (bufferPanel.Focused && this.HasImage)
            {
                if (e.Button == MouseButtons.Left)
                {
                    mSelection.Width = e.X - mSelection.Location.X;
                    mSelection.Height = e.Y - mSelection.Location.Y;

                    bufferPanel.Invalidate();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    mImageRect.X += (e.X - mMouseLocation.X);
                    mImageRect.Y += (e.Y - mMouseLocation.Y);

                    bufferPanel.Invalidate();
                }
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

                    UpdateScaleInfo();

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

        public void OnClassNameChange()
        {
            bufferPanel.Invalidate();
        }
    }
}
