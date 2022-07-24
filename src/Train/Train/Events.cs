using System;

namespace Train
{
    class BeforeRenameEventArgs : EventArgs
    {
        public string Name { get; set; }
        public bool Cancel { get; set; }
    }

    class GetImageClassNameArgs : EventArgs
    {
        public ClassName ClassName { get; set; }
    }
}
