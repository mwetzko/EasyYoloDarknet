using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

        public static string EnsureProjectTrainPath(string projPath)
        {
            string path = Path.Combine(projPath, "Data");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public static bool EnsurePreTrainedWeights(out string filename)
        {
            var fi = new FileInfo(Path.Combine(Path.GetDirectoryName(typeof(MainForm).Assembly.Location), "YoloTrain", "yolov4.conv.137"));

            filename = fi.FullName;

            return fi.Exists && fi.Length > 0;
        }

        public static bool EnsureYoloConfig(string dataPath, int numimages, int numclasses, int batch, int subdivisions, int width, int height, out string configFilename)
        {
            string source = Path.Combine(Path.GetDirectoryName(typeof(MainForm).Assembly.Location), "YoloTrain", "yolov4-custom.cfg");

            if (!File.Exists(source))
            {
                configFilename = null;
                return false;
            }

            // update yolov4-custom.cfg based on https://github.com/AlexeyAB/darknet#how-to-train-to-detect-your-custom-objects

            string[] content = File.ReadAllLines(source);

            string section = null;
            UpdatableConfigValue filtersLine = null;

            for (int i = 0; i < content.Length; i++)
            {
                var m = Regex.Match(content[i], "^[\t ]*\\[([^\\[\\]]+)\\]");

                if (m.Success)
                {
                    section = m.Groups[1].Value.ToLowerInvariant();

                    if (section == "yolo")
                    {
                        if (filtersLine != null)
                        {
                            filtersLine.Value = $"{(numclasses + 5) * 3}";
                            filtersLine = null;
                        }
                    }

                    continue;
                }

                var line = new UpdatableConfigValue(content, i);

                if (line.Success)
                {
                    if (section == "net")
                    {
                        if (line.Command == "batch")
                        {
                            line.Value = $"{batch}";
                        }
                        else if (line.Command == "subdivisions")
                        {
                            line.Value = $"{subdivisions}";
                        }
                        else if (line.Command == "max_batches" || line.Command == "steps")
                        {
                            int num = numclasses * 2000;

                            if (num < 6000)
                            {
                                num = 6000;
                            }

                            if (num < numimages)
                            {
                                num = numimages;
                            }

                            if (line.Command == "max_batches")
                            {
                                line.Value = $"{num}";
                            }
                            else
                            {
                                line.Value = $"{(int)(num * 0.8)},{(int)(num * 0.9)}";
                            }
                        }
                        else if (line.Command == "width")
                        {
                            line.Value = $"{width}";
                        }
                        else if (line.Command == "height")
                        {
                            line.Value = $"{height}";
                        }
                    }
                    else if (section == "yolo")
                    {
                        if (line.Command == "classes")
                        {
                            line.Value = $"{numclasses}";
                        }
                    }
                    else if (section == "convolutional")
                    {
                        if (line.Command == "filters")
                        {
                            filtersLine = line;
                        }
                    }
                }
            }

            configFilename = Path.Combine(dataPath, "yolov4-custom.cfg");

            File.WriteAllLines(configFilename, content);

            return true;
        }

        public static void EnsureObjectNames(string dataPath, ClassName[] classes, out string filename)
        {
            filename = Path.Combine(dataPath, "obj.names");

            File.WriteAllLines(filename, classes.Select(x => x.Name).ToArray());

            filename = Path.Combine(dataPath, "obj.data");

            string backup = Path.Combine(dataPath, "backup");

            if (!Directory.Exists(backup))
            {
                Directory.CreateDirectory(backup);
            }

            File.WriteAllLines(filename,
                new string[]
                {
                    $"classes={classes.Length}",
                    $"train={Path.Combine(dataPath, "train.txt")}",
                    $"valid={Path.Combine(dataPath, "valid.txt")}",
                    $"names={filename}",
                    $"backup={backup}",
                });
        }

        public static void EnsureImages(string dataPath, string imagesPath, ClassName[] classes, ImageInfo[] images)
        {
            List<string> imagesUsed = new List<string>();

            foreach (var item in images)
            {
                if (item.Marks != null)
                {
                    imagesUsed.Add(Path.Combine(imagesPath, item.Name));

                    List<string> markInfo = new List<string>();

                    foreach (var mark in item.Marks)
                    {
                        markInfo.Add($"{Array.IndexOf(classes, mark.ClassName)} {mark.CenterX:0.000000} {mark.CenterY:0.000000} {mark.Width:0.000000} {mark.Height:0.000000}");
                    }

                    File.WriteAllLines(Path.Combine(imagesPath, Path.GetFileNameWithoutExtension(item.Name) + ".txt"), markInfo.ToArray());
                }
            }

            File.WriteAllLines(Path.Combine(dataPath, "train.txt"), imagesUsed.ToArray());
        }
    }
}
