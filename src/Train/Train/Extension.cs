using System;
using System.Drawing;

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

        public static Rectangle GetRectangle(this ImageMark im, Rectangle imageRect)
        {
            Rectangle rect = new Rectangle();

            rect.Width = (int)(imageRect.Width * im.Width);
            rect.Height = (int)(imageRect.Height * im.Height);
            rect.X = imageRect.X + (int)((imageRect.Width * im.CenterX) - (rect.Width / 2f));
            rect.Y = imageRect.Y + (int)((imageRect.Height * im.CenterY) - (rect.Height / 2f));

            return rect;
        }
    }
}
