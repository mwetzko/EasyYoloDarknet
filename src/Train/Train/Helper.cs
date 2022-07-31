using System.Drawing;
using System.Windows.Forms;

namespace Train
{
    static class Helper
    {
        public static Cursor GetResizeCursor(RectangleF rect, Point mouseLocation)
        {
            if (IsBetween(rect.Left, mouseLocation.X))
            {
                if (IsBetween(rect.Top, mouseLocation.Y))
                {
                    return Cursors.SizeNWSE;
                }
                else if (IsBetween(rect.Bottom, mouseLocation.Y))
                {
                    return Cursors.SizeNESW;
                }
                else
                {
                    return Cursors.SizeWE;
                }
            }
            else if (IsBetween(rect.Right, mouseLocation.X))
            {
                if (IsBetween(rect.Top, mouseLocation.Y))
                {
                    return Cursors.SizeNESW;
                }
                else if (IsBetween(rect.Bottom, mouseLocation.Y))
                {
                    return Cursors.SizeNWSE;
                }
                else
                {
                    return Cursors.SizeWE;
                }
            }
            else if (IsBetween(rect.Top, mouseLocation.Y) || IsBetween(rect.Bottom, mouseLocation.Y))
            {
                return Cursors.SizeNS;
            }

            return null;
        }

        static bool IsBetween(float edge, int value)
        {
            return value >= edge - 4 && value <= edge + 4;
        }
    }
}
