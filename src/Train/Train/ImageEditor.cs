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
        Rectangle mImageRect;
        bool mFromCenter;
        bool mHasSelection;
        Rectangle mSelection;
        Font mScaleFont;
        bool mHasCtrl;
        MouseEventArgs mLastMouseEvent;

        public ImageEditor()
        {
            InitializeComponent();

            pnlMarks.Visible = false;

            bufferPanel.MouseWheel += bufferPanel_MouseWheel;
            bufferPanel.KeyDown += bufferPanel_KeyDown;
            bufferPanel.KeyUp += bufferPanel_KeyUp;

            this.DoubleBuffered = true;

            UpdateScaleInfo();
        }

        public event EventHandler<GetImageClassNameArgs> GetImageClassName;
        public event EventHandler DeleteMarks;

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

                LoadImage();
            }
        }

        Image Image => mImageControl?.Image;

        IList<ImageMark> Marks => mImageControl?.Marks;

        bool HasImage => this.Image != null;

        void LoadImage()
        {
            pnlMarksList.Controls.Clear();

            if (this.HasImage)
            {
                pnlMarks.Visible = true;
                pnlMarksList.AutoSize = true;
                pnlMarksList.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                if (this.Marks != null)
                {
                    foreach (var item in this.Marks)
                    {
                        var mc = new MarkControl(item);
                        mc.Dock = DockStyle.Top;
                        mc.DeleteMark += Mc_DeleteMark;
                        mc.MouseEnter += Mc_MouseEnter;
                        mc.MouseLeave += Mc_MouseLeave;
                        pnlMarksList.Controls.Add(mc);
                    }
                }

                CalcImageSize();
                CenterImage();

                bufferPanel.Invalidate();
            }
            else
            {
                pnlMarks.Visible = false;
            }
        }

        void Mc_MouseLeave(object sender, EventArgs e)
        {
            ((MarkControl)sender).Mark.DrawHighlight = false;
            bufferPanel.Invalidate();
        }

        void Mc_MouseEnter(object sender, EventArgs e)
        {
            ((MarkControl)sender).Mark.DrawHighlight = true;
            bufferPanel.Invalidate();
        }

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
            if (mImageRect.Contains(mLastMouseEvent.Location))
            {
                mImageRect.X = mLastMouseEvent.X - (int)(((mLastMouseEvent.X - mImageRect.X) / (float)formerImageSize.Width) * mImageRect.Width);
                mImageRect.Y = mLastMouseEvent.Y - (int)(((mLastMouseEvent.Y - mImageRect.Y) / (float)formerImageSize.Height) * mImageRect.Height);
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

                    var rect = item.GetRectangleF(mImageRect);

                    using (Brush b = new SolidBrush(c))
                    {
                        e.Graphics.DrawString(item.ClassName.Name, mScaleFont, b, rect.Location);
                    }

                    using (Pen p = new Pen(c))
                    {
                        e.Graphics.DrawRectangle(p, rect);

                        if (item.DrawMouseOver || item.DrawHighlight)
                        {
                            e.Graphics.DrawRectangle(p, RectangleF.Inflate(rect, 1, 1));
                        }
                    }
                }

                if (mHasSelection && mSelection.Width != 0 && mSelection.Height != 0)
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
            mLastMouseEvent = e;

            if (!mHasCtrl && this.HasImage)
            {
                if (e.Button == MouseButtons.Left && mImageRect.Contains(e.Location))
                {
                    mHasSelection = true;
                    mSelection = new Rectangle(e.Location, new Size(0, 0));
                }
            }
        }

        void bufferPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mLastMouseEvent = e;

            if (this.HasImage)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (mHasSelection)
                    {
                        mHasSelection = false;

                        if (mSelection.Width != 0 && mSelection.Height != 0)
                        {
                            GetImageClassNameArgs args = new GetImageClassNameArgs();

                            GetImageClassName?.Invoke(this, args);

                            if (args.ClassName != null)
                            {
                                if (mSelection.Width < 0)
                                {
                                    mSelection.X += mSelection.Width;
                                    mSelection.Width = -mSelection.Width;
                                }

                                if (mSelection.Height < 0)
                                {
                                    mSelection.Y += mSelection.Height;
                                    mSelection.Height = -mSelection.Height;
                                }

                                float w = (float)mSelection.Width / (float)mImageRect.Width;
                                float h = (float)mSelection.Height / (float)mImageRect.Height;
                                float x = ((mSelection.X - mImageRect.X) + (mSelection.Width / 2f)) / (float)mImageRect.Width;
                                float y = ((mSelection.Y - mImageRect.Y) + (mSelection.Height / 2f)) / (float)mImageRect.Height;

                                var mc = new MarkControl(this.ImageControl.AddImageMark(args.ClassName, new RectangleF(x, y, w, h)));
                                mc.Dock = DockStyle.Top;
                                mc.DeleteMark += Mc_DeleteMark;
                                mc.MouseEnter += Mc_MouseEnter;
                                mc.MouseLeave += Mc_MouseLeave;
                                pnlMarksList.Controls.Add(mc);
                            }
                        }

                        mSelection.Width = 0;
                        mSelection.Height = 0;

                        bufferPanel.Invalidate();
                    }
                }
            }
        }

        void bufferPanel_MouseMove(object sender, MouseEventArgs e)
        {
            var ev = mLastMouseEvent;

            mLastMouseEvent = e;

            if (this.HasImage)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (mHasSelection)
                    {
                        mSelection.Width = e.X - mSelection.Location.X;
                        mSelection.Height = e.Y - mSelection.Location.Y;

                        bufferPanel.Invalidate();
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    mImageRect.X += (e.X - ev.X);
                    mImageRect.Y += (e.Y - ev.Y);

                    bufferPanel.Invalidate();
                }
                else if (this.Marks != null)
                {
                    bool refresh = false;
                    RectangleF? resz = null;

                    foreach (var item in this.Marks)
                    {
                        var rect = item.GetRectangleF(mImageRect);
                        RectangleF? rect2 = null;

                        if (!resz.HasValue && mHasCtrl)
                        {
                            rect2 = RectangleF.Inflate(rect, 4, 4);
                        }

                        bool contains = (rect2 ?? rect).Contains(e.Location);

                        if (contains != item.DrawMouseOver)
                        {
                            item.DrawMouseOver = contains;
                            refresh = true;
                        }

                        if (!resz.HasValue && mHasCtrl && contains)
                        {
                            var rect3 = RectangleF.Inflate(rect, -4, -4);

                            if (rect3.Width > 0 && rect3.Height > 0)
                            {
                                contains = rect3.Contains(e.Location);

                                if (!contains)
                                {
                                    resz = rect;
                                }
                            }
                        }
                    }

                    if (resz.HasValue)
                    {
                        this.Cursor = Helper.GetResizeCursor(resz.Value, e.Location) ?? Cursors.Default;
                    }
                    else if (this.Cursor != Cursors.Default)
                    {
                        this.Cursor = Cursors.Default;
                    }

                    if (refresh)
                    {
                        bufferPanel.Invalidate();
                    }
                }
            }
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

            foreach (var item in pnlMarksList.Controls)
            {
                ((MarkControl)item).UpdateState();
            }
        }

        void bufferPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!mHasCtrl)
                {
                    mHasSelection = false;

                    bufferPanel.Invalidate();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (!mHasCtrl && this.Marks != null)
                {
                    bool refresh = false;

                    for (int i = 0; i < this.Marks.Count; i++)
                    {
                        var rect = this.Marks[i].GetRectangleF(mImageRect);

                        bool contains = rect.Contains(mLastMouseEvent.Location);

                        if (contains)
                        {
                            ProjectState.RemoveMark(this.Marks[i]);
                            pnlMarksList.Controls.RemoveAt(i);
                            this.Marks.RemoveAt(i--);
                            refresh = true;
                        }
                    }

                    if (refresh)
                    {
                        DeleteMarks?.Invoke(this, EventArgs.Empty);
                        bufferPanel.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.ControlKey)
            {
                if (!mHasCtrl && !mHasSelection)
                {
                    mHasCtrl = true;

                    if (mLastMouseEvent != null)
                    {
                        bufferPanel_MouseMove(bufferPanel, mLastMouseEvent);
                    }
                }
            }
        }

        void bufferPanel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                mHasCtrl = false;

                if (mLastMouseEvent != null)
                {
                    bufferPanel_MouseMove(bufferPanel, mLastMouseEvent);
                }
            }
        }

        void bufferPanel_MouseEnter(object sender, EventArgs e)
        {
            bufferPanel.Focus();
        }

        void PaintBottomLine(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawBottomLine((Control)sender);
        }

        void ImageListControlsChanged(object sender, ControlEventArgs e)
        {
            if (pnlMarksList.Controls.Count == 0)
            {
                lbMarks.Text = "Marks";
            }
            else
            {
                lbMarks.Text = $"Marks ({pnlMarksList.Controls.Count})";
            }
        }

        void Mc_DeleteMark(object sender, EventArgs e)
        {
            MarkControl mc = (MarkControl)sender;

            int pos = this.Marks.IndexOf(mc.Mark);

            ProjectState.RemoveMark(mc.Mark);
            pnlMarksList.Controls.RemoveAt(pos);
            this.Marks.RemoveAt(pos);

            DeleteMarks?.Invoke(this, EventArgs.Empty);
            bufferPanel.Invalidate();
        }
    }
}
