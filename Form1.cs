using System;
using System.Drawing;
using System.Windows.Forms;

namespace paint_application
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
                var penTool = new PenTool(pictureBox1);
        }
    } 
}
