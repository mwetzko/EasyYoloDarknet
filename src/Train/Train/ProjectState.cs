using System;
using System.Collections.Generic;

namespace Train
{
    static class ProjectState
    {
        static IDictionary<string, ClassName> Classes = new Dictionary<string, ClassName>();
        static List<ImageMark> Marks = new List<ImageMark>();

        public static void AddClass(ClassName cn)
        {
            lock (Classes)
            {
                Classes.TryAdd(cn.ID, cn);
            }
        }

        public static void RemoveClass(string cid)
        {
            lock (Marks)
            {
                for (int i = 0; i < Marks.Count; i++)
                {
                    if (string.Equals(Marks[i].ClassId, cid, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Marks.RemoveAt(i--);
                    }
                }
            }

            lock (Classes)
            {
                Classes.Remove(cid);
            }
        }

        public static void AddMarks(ImageMark[] marks)
        {
            if (marks == null)
            {
                return;
            }

            lock (Marks)
            {
                Marks.AddRange(marks);
            }
        }

        public static void AddMark(ImageMark mark)
        {
            if (mark == null)
            {
                return;
            }

            lock (Marks)
            {
                Marks.Add(mark);
            }
        }

        public static void RemoveMarks(ImageMark[] marks)
        {
            if (marks == null)
            {
                return;
            }

            lock (Marks)
            {
                foreach (var item in marks)
                {
                    Marks.Remove(item);
                }
            }
        }

        public static void Clear()
        {
            lock (Classes)
            {
                Classes.Clear();
            }

            lock (Marks)
            {
                Marks.Clear();
            }
        }
    }
}
