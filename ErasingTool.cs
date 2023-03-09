﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace paint_application
{
    public class EreaseTool
    {
        private PictureBox pictureBox;
        private Point? previousPoint;
        private Pen erasingPen = new Pen(Color.White, 1);
        private List<Point> points = new List<Point>();

        public EreaseTool(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.Paint += PictureBox_Paint;
        }
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            previousPoint = e.Location;
        }
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && previousPoint.HasValue)
            {
                using (var graphics = pictureBox.CreateGraphics())
                {
                    graphics.DrawLine(erasingPen, previousPoint.Value, e.Location);
                }
                points.Add(previousPoint.Value);
                points.Add(e.Location);
                previousPoint = e.Location;
            }
        }
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            using (var graphics = e.Graphics)
            {
                graphics.DrawLines(erasingPen, points.ToArray());
            }
        }
    }
}