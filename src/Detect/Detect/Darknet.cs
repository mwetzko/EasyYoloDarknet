using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Detect
{
    static class Darknet
    {
        [DllImport(".\\x64\\darknet.dll", EntryPoint = "init")]
        static extern int Init64([MarshalAs(UnmanagedType.LPUTF8Str)] string configurationFilename, string weightsFilename, int gpu, int batch_size);

        [DllImport(".\\x86\\darknet.dll", EntryPoint = "init")]
        static extern int Init32([MarshalAs(UnmanagedType.LPUTF8Str)] string configurationFilename, string weightsFilename, int gpu, int batch_size);

        static int Init(string configurationFilename, string weightsFilename, int gpu, int batch_size)
        {
            if (IntPtr.Size == sizeof(int))
            {
                return Init32(configurationFilename, weightsFilename, gpu, batch_size);
            }
            else
            {
                return Init64(configurationFilename, weightsFilename, gpu, batch_size);
            }
        }

        [DllImport(".\\x64\\darknet.dll", EntryPoint = "detect_image")]
        static extern int DetectImage64([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, ref BboxContainer container);

        [DllImport(".\\x86\\darknet.dll", EntryPoint = "detect_image")]
        static extern int DetectImage32([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, ref BboxContainer container);

        static int DetectImage(string filename, ref BboxContainer container)
        {
            if (IntPtr.Size == sizeof(int))
            {
                return DetectImage32(filename, ref container);
            }
            else
            {
                return DetectImage64(filename, ref container);
            }
        }

        [DllImport(".\\x64\\darknet.dll", EntryPoint = "detect_mat")]
        static extern int DetectImage64(IntPtr pArray, int nSize, ref BboxContainer container);

        [DllImport(".\\x86\\darknet.dll", EntryPoint = "detect_mat")]
        static extern int DetectImage32(IntPtr pArray, int nSize, ref BboxContainer container);

        static int DetectImage(IntPtr pArray, int nSize, ref BboxContainer container)
        {
            if (IntPtr.Size == sizeof(int))
            {
                return DetectImage32(pArray, nSize, ref container);
            }
            else
            {
                return DetectImage64(pArray, nSize, ref container);
            }
        }

        [DllImport(".\\x64\\darknet.dll", EntryPoint = "dispose")]
        static extern int Dispose64();

        [DllImport(".\\x86\\darknet.dll", EntryPoint = "dispose")]
        static extern int Dispose32();

        static int Dispose()
        {
            if (IntPtr.Size == sizeof(int))
            {
                return Dispose32();
            }
            else
            {
                return Dispose64();
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct bbox_t
        {
            public uint x, y, w, h;    // (x,y) - top-left corner, (w, h) - width & height of bounded box
            public float prob;           // confidence - probability that the object was found correctly
            public uint obj_id;        // class of object - from range [0, classes-1]
            public uint track_id;      // tracking id for video (0 - untracked, 1 - inf - tracked object)
            public uint frames_counter;
            public float x_3d, y_3d, z_3d;  // 3-D coordinates, if there is used 3D-stereo camera
        }

        [StructLayout(LayoutKind.Sequential)]
        struct BboxContainer
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
            public bbox_t[] candidates;
        }

        public static bbox_t[] Detect(string filename)
        {
            var cfg = Path.Combine(Path.GetDirectoryName(typeof(Darknet).Assembly.Location), "Yolo", "yolov4.cfg");
            var weights = Path.Combine(Path.GetDirectoryName(typeof(Darknet).Assembly.Location), "Yolo", "yolov4.weights");

            Init(cfg, weights, 0, 1);

            var container = new BboxContainer();

            var count = DetectImage(filename, ref container);

            Dispose();

            return container.candidates.Take(count).ToArray();
        }
    }
}
