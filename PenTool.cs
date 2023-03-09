using System.Drawing;
using System.Windows.Forms;

namespace PenToolExample
{
    public class PenTool
    {
        private Point? previousPoint;
        private Pen pen;
        private PictureBox pictureBox;

        public PenTool(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            this.pen = new Pen(Color.Black, 1); // толщина линии - 2
            this.pictureBox.MouseMove += PictureBox_MouseMove;
            this.pictureBox.MouseDown += PictureBox_MouseDown;
            this.pictureBox.MouseUp += PictureBox_MouseUp;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (previousPoint.HasValue)
            {
                Point currentPoint = e.Location;
                using (Graphics g = pictureBox.CreateGraphics())
                {
                    g.DrawLine(pen, previousPoint.Value, currentPoint);
                }
                previousPoint = currentPoint;
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            previousPoint = e.Location;
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            previousPoint = null;
        }

        public void SetPenColor(Color color)
        {
            pen.Color = color;
        }

        public void SetPenWidth(float width)
        {
            pen.Width = width;
        }
    }
}
