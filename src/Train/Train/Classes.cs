namespace Train
{
    class ProjectData
    {
        public ClassName[] Classes { get; set; }
        public ImageInfo[] Images { get; set; }
    }

    class ClassName
    {
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
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }
}
