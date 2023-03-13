using System.Drawing;
using System.Windows.Forms;

namespace paint_application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bitmapImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphicsEngine = Graphics.FromImage(bitmapImage);
            graphicsEngine.Clear(Color.White);
            pictureBox1.Image = bitmapImage;
        }
        Bitmap bitmapImage;
        Graphics graphicsEngine;
        Point px, py;
        Pen penPaint = new Pen(Color.Black, 1);
        Pen erasePaint = new Pen(Color.White, 1);

        int indexPaint;
        bool isPaint = false;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isPaint = true;
            py = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPaint)
            {
                if(indexPaint == 1)
                {
                    px = e.Location;
                    graphicsEngine.DrawLine(penPaint, px, py);
                    py = px;
                }
                if(indexPaint == 2)
                {
                    px = e.Location;
                    graphicsEngine.DrawLine(erasePaint, py, px);
                    py = px;
                }
            }
            pictureBox1.Refresh();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            indexPaint = 1; // penPaint
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            indexPaint = 2; // erasePaint
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isPaint = false;
        }
    }
}