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
    }
}
