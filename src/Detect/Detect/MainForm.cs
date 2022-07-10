using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Detect
{
    partial class MainForm : Form
    {
        string mFilename;
        Color[] mColors;

        public MainForm(string filename)
        {
            mFilename = filename;

            InitializeComponent();

            mColors = typeof(Color).GetProperties().Where(x => x.PropertyType == typeof(Color) && (Color)x.GetValue(null) != Color.Transparent).Select(x => (Color)x.GetValue(null)).ToArray();
        }

        protected override void OnLoad(EventArgs e)
        {
            var objects = Darknet.Detect(mFilename);

            var names = Path.Combine(Path.GetDirectoryName(typeof(MainForm).Assembly.Location), "Yolo", "coco.names");

            string[] classes = File.ReadAllLines(names);

            Bitmap bm = new Bitmap(mFilename);

            using (Graphics g = Graphics.FromImage(bm))
            {
                foreach (var item in objects)
                {
                    using (Brush b = new SolidBrush(mColors[item.obj_id % mColors.Length]))
                    {
                        using (Pen p = new Pen(b))
                        {
                            g.DrawRectangle(p, (int)item.x, (int)item.y, (int)item.w, (int)item.h);
                            g.DrawString(classes[item.obj_id], this.Font, b, (int)item.x, (int)item.y);
                        }
                    }
                }
            }

            this.BackgroundImage = bm;
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}