using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Train
{
    unsafe static class Darknet
    {
        [DllImport(".\\x64\\darknet.dll", EntryPoint = "ResetStdOutBehavior")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern void ResetStdOutBehavior64();

        [DllImport(".\\x86\\darknet.dll", EntryPoint = "ResetStdOutBehavior")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern void ResetStdOutBehavior32();

        public static void ResetStdOutBehavior()
        {
            if (IntPtr.Size == sizeof(int))
            {
                ResetStdOutBehavior32();
            }
            else
            {
                ResetStdOutBehavior64();
            }
        }

        [DllImport(".\\x64\\darknet.dll", EntryPoint = "SetStdOutBehavior")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetStdOutBehavior64(out IntPtr hStdOut, out IntPtr hStdErr);

        [DllImport(".\\x86\\darknet.dll", EntryPoint = "SetStdOutBehavior")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetStdOutBehavior32(out IntPtr hStdOut, out IntPtr hStdErr);

        public static bool SetStdOutBehavior(out IntPtr hStdOut, out IntPtr hStdErr)
        {
            if (IntPtr.Size == sizeof(int))
            {
                return SetStdOutBehavior32(out hStdOut, out hStdErr);
            }
            else
            {
                return SetStdOutBehavior64(out hStdOut, out hStdErr);
            }
        }

        [DllImport(".\\x64\\darknet.dll", EntryPoint = "SetExitBehavior")]
        static extern void SetExitBehavior64([MarshalAs(UnmanagedType.Bool)] bool useThrow);

        [DllImport(".\\x86\\darknet.dll", EntryPoint = "SetExitBehavior")]
        static extern void SetExitBehavior32([MarshalAs(UnmanagedType.Bool)] bool useThrow);

        public static void SetExitBehavior(bool useThrow)
        {
            if (IntPtr.Size == sizeof(int))
            {
                SetExitBehavior32(useThrow);
            }
            else
            {
                SetExitBehavior64(useThrow);
            }
        }

        [DllImport(".\\x64\\darknet.dll", EntryPoint = "run_detector")]
        static extern void RunDetector64(int argc, IntPtr argv);

        [DllImport(".\\x86\\darknet.dll", EntryPoint = "run_detector")]
        static extern void RunDetector32(int argc, IntPtr argv);

        public static void RunDetector(string[] args)
        {
            var handles = args.Select(x => GCHandle.Alloc(Encoding.UTF8.GetBytes(x), GCHandleType.Pinned));

            try
            {
                fixed (IntPtr* ptrs = handles.Select(x => x.AddrOfPinnedObject()).ToArray())
                {
                    if (IntPtr.Size == sizeof(int))
                    {
                        RunDetector32(args.Length, (IntPtr)ptrs);
                    }
                    else
                    {
                        RunDetector64(args.Length, (IntPtr)ptrs);
                    }
                }
            }
            finally
            {
                foreach (var item in handles)
                {
                    item.Free();
                }
            }
        }
    }
}
