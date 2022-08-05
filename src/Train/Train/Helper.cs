using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Train
{
    static class Helper
    {
        public const string PRE_TRAINED_WEIGHTS_URL = "https://github.com/AlexeyAB/darknet/releases/download/darknet_yolo_v3_optimal/yolov4.conv.137";

        public static Cursor GetResizeCursor(RectangleF rect, Point mouseLocation, out LTRB rmp)
        {
            rmp = default;

            if (IsBetween(rect.Left, mouseLocation.X))
            {
                rmp.Left = 1;

                if (IsBetween(rect.Top, mouseLocation.Y))
                {
                    rmp.Top = 1;
                    return Cursors.SizeNWSE;
                }
                else if (IsBetween(rect.Bottom, mouseLocation.Y))
                {
                    rmp.Bottom = 1;
                    return Cursors.SizeNESW;
                }
                else
                {
                    return Cursors.SizeWE;
                }
            }
            else if (IsBetween(rect.Right, mouseLocation.X))
            {
                rmp.Right = 1;

                if (IsBetween(rect.Top, mouseLocation.Y))
                {
                    rmp.Top = 1;
                    return Cursors.SizeNESW;
                }
                else if (IsBetween(rect.Bottom, mouseLocation.Y))
                {
                    rmp.Bottom = 1;
                    return Cursors.SizeNWSE;
                }
                else
                {
                    return Cursors.SizeWE;
                }
            }
            else if (IsBetween(rect.Top, mouseLocation.Y))
            {
                rmp.Top = 1;
                return Cursors.SizeNS;
            }
            else if (IsBetween(rect.Bottom, mouseLocation.Y))
            {
                rmp.Bottom = 1;
                return Cursors.SizeNS;
            }

            return null;
        }

        static bool IsBetween(float edge, int value)
        {
            return value >= edge - 4 && value <= edge + 4;
        }

        public static void EnsureYoloTrainPath()
        {
            var path = Path.Combine(Path.GetDirectoryName(typeof(MainForm).Assembly.Location), "YoloTrain");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static bool EnsurePreTrainedWeights(out string filename)
        {
            var fi = new FileInfo(Path.Combine(Path.GetDirectoryName(typeof(MainForm).Assembly.Location), "YoloTrain", "yolov4.conv.137"));

            filename = fi.FullName;

            return fi.Exists && fi.Length > 0;
        }
    }
}
