using System.Drawing;
using System.Windows.Forms;

namespace paint_application
{
    public class DrawingTools
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        private bool _paint;
        private Point _pointX, _pointY;
        private Pen _pensil;

        public DrawingTools(PictureBox pictureBox, PenSettings penSettings)
        {
            _bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.Clear(Color.White);
            pictureBox.Image = _bitmap;

            _pensil = new Pen(penSettings.Color, penSettings.Width);
        }

        public void StartDrawing(MouseEventArgs e)
        {
            _paint = true;
            _pointY = e.Location;
        }

        public void Draw(MouseEventArgs e)
        {
            if (_paint)
            {
                _pointX = e.Location;
                _graphics.DrawLine(_pensil, _pointX, _pointY);
                _pointY = _pointX;
            }
        }

        public void EndDrawing()
        {
            _paint = false;
        }
    }
}
