using System;
using System.Drawing;
using System.Windows.Forms;

namespace Train
{
    static class Extension
    {
        public static bool Contains<T>(this T[] array, Func<T, bool> predicate)
        {
            foreach (var item in array)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static void DrawBottomLine(this Graphics g, Control c)
        {
            g.DrawLine(Pens.Gray, 0, c.Height - 1, c.Width - 1, c.Height - 1);
        }

        public static void DrawRectangle(this Graphics g, Pen p, RectangleF rect)
        {
            g.DrawRectangle(p, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public static RectangleF GetRectangleF(this ImageMark im, Rectangle imageRect)
        {
            RectangleF rect = new RectangleF();

            rect.Width = imageRect.Width * im.Width;
            rect.Height = imageRect.Height * im.Height;
            rect.X = imageRect.X + ((imageRect.Width * im.CenterX) - (rect.Width / 2f));
            rect.Y = imageRect.Y + ((imageRect.Height * im.CenterY) - (rect.Height / 2f));

            return rect;
        }

        public static LTRB ToLTRB(this RectangleF rect)
        {
            return new LTRB() { Left = rect.Left, Top = rect.Top, Right = rect.Right, Bottom = rect.Bottom };
        }

        public static RectangleF ToRectangleF(this LTRB rect)
        {
            return RectangleF.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        public static void Update(this ImageMark im, RectangleF relativeRect)
        {
            im.CenterX = relativeRect.X;
            im.CenterY = relativeRect.Y;
            im.Width = Math.Abs(relativeRect.Width);
            im.Height = Math.Abs(relativeRect.Height);

            im.Control?.UpdateState();
        }
    }
}
