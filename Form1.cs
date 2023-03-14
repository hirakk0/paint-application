using System.Windows.Forms;

namespace paint_application
{
    public partial class Form1 : Form
    {
        private paintManager paintManager;

        public Form1()
        {
            InitializeComponent();
            paintManager = new paintManager(pictureBox1, pictureBox2, pictureBox3);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            paintManager.SetPenPaint();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            paintManager.SetErasePaint();
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            paintManager.SetEllipsePaint();
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            paintManager.SetRectanglePaint();
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            paintManager.SetLinePaint();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paintManager.OnMouseDown(e.Location, e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            paintManager.OnMouseMove(e.Location, e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paintManager.OnMouseUp(e.X, e.Y);
        }

        private void button10_Click(object sender, System.EventArgs e)
        {
            paintManager.SetFormClear();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            paintManager.PencilColorSelection();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            paintManager.OnMousePictureBox2Click(e.Location);
        }

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            paintManager.OnMousePictureBoxClick(e.Location);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            paintManager.SetFillPaint();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            paintManager.SaveToFile();
        }
    }
}