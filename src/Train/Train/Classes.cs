using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Train
{
    class ProjectData
    {
        public ClassName[] Classes { get; set; }
        public ImageInfo[] Images { get; set; }
    }

    class ClassName
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Color { get; set; }
    }

    class ImageInfo
    {
        public string Name { get; set; }
        public ImageMark[] Marks { get; set; }
    }

    class ImageMark
    {
        public string ClassId { get; set; }
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        [JsonIgnore]
        public ClassName ClassName { get; set; }
        [JsonIgnore]
        public bool DrawMouseOver { get; set; }
        [JsonIgnore]
        public bool DrawHighlight { get; set; }
        [JsonIgnore]
        public MarkControl Control { get; set; }
    }

    struct LTRB
    {
        public float Left;
        public float Top;
        public float Right;
        public float Bottom;
    }

    class UpdatableConfigValue
    {
        string[] mArray;
        int mIndex;
        Match mMatch;
        Lazy<string> mCommand;

        public UpdatableConfigValue(string[] array, int index)
        {
            mArray = array;
            mIndex = index;
            mMatch = Regex.Match(array[index], "^[\t ]*([a-z_-]+)[\t ]*=([^\r\n]*)");
            mCommand = new Lazy<string>(() => mMatch.Groups[1].Value.ToLowerInvariant(), true);
        }

        public bool Success => mMatch.Success;

        public string Command => mCommand.Value;

        public string Value { get => mMatch.Groups[2].Value; set => mArray[mIndex] = $"{mMatch.Groups[1].Value}={value}"; }
    }
}
