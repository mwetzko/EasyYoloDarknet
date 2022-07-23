using System.Windows.Forms;

namespace Train
{
    class BufferPanel : Panel
    {
        public BufferPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}
