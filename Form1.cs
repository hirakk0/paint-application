using System.Drawing;
using System.Windows.Forms;

namespace paint_application
{
    public partial class Form1 : Form
    {
        private DrawingTools _drawingTools;

        public Form1()
        {
            InitializeComponent();

            this.Width = 900;
            this.Height = 700;

            var penSettings = new PenSettings(Color.Black, 1);
            _drawingTools = new DrawingTools(pictureBox1, penSettings);
            pictureBox1.Enabled = false; // выключаем pictureBox1 до тех пор, пока не будет нажата кнопка
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _drawingTools.Draw(e);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _drawingTools.EndDrawing();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            var penSettings = new PenSettings(Color.Black, 1);
            _drawingTools = new DrawingTools(pictureBox1, penSettings);
            pictureBox1.Enabled = true; // включаем pictureBox1 после нажатия кнопки
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _drawingTools.StartDrawing(e);
        }
    }
}
