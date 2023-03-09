using PenToolExample;
using System.Windows.Forms;

namespace paint_application
{
    public partial class Form1 : Form
    {
        private PenTool penTool;
        private EreaseTool ereaseTool;

        public Form1()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, System.EventArgs e)
        {
            penTool = new PenTool(pictureBox1);
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            EreaseTool ereaseTool = new EreaseTool(pictureBox1);
        }
    }
}