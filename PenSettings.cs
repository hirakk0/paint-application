using System.Drawing;

namespace paint_application
{
    public class PenSettings
    {
        public Color Color { get; set; }
        public float Width { get; set; }

        public PenSettings(Color color, float width)
        {
            Color = color;
            Width = width;
        }
    }
}
