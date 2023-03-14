using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace paint_application
{
    class paintManager : Form
    {
        private PictureBox pictureBox;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Bitmap bitmapImage;
        private Graphics graphicsEngine;
        private Point px, py;
        private Pen penPaint = new Pen(Color.Black, 1);
        private Pen erasePaint = new Pen(Color.White, 1);

        private int indexPaint;
        private int x, y, sX, sY, cX, cY;
        private bool isPaint = false;

        ColorDialog colorDialog = new ColorDialog();
        Color color;

        public paintManager(PictureBox pictureBox, PictureBox pictureBox2, PictureBox pictureBox3)
        {
            this.pictureBox = pictureBox;
            this.pictureBox2 = pictureBox2;
            this.pictureBox3 = pictureBox3;
            bitmapImage = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphicsEngine = Graphics.FromImage(bitmapImage);
            graphicsEngine.Clear(Color.White);
            pictureBox.Image = bitmapImage;
        }

        public void SetPenPaint()
        {
            indexPaint = 1;
        }

        public void SetErasePaint()
        {
            indexPaint = 2;
        }

        public void SetEllipsePaint()
        {
            indexPaint = 3;
        }

        public void SetRectanglePaint()
        {
            indexPaint = 4;
        }

        public void SetLinePaint()
        {
            indexPaint = 5;
        }

        public void SetFillPaint()
        {
            indexPaint = 6;
        }

        public void SetFormClear()
        {
            graphicsEngine.Clear(Color.White);
            pictureBox.Image = bitmapImage;
            indexPaint = 0;
        }

        public void PencilColorSelection()
        {
            colorDialog.ShowDialog();
            color = colorDialog.Color;
            pictureBox3.BackColor = colorDialog.Color;
            penPaint.Color = colorDialog.Color;
        }

        static Point setPoint(PictureBox pb, Point point)
        {
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(point.X * pX), (int)(point.Y * pY));
        }

        private void validateFill(Bitmap bm, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
        { 
            Color cx = bm.GetPixel(x, y);
            
            if(cx == old_color)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y , new_color);
            }
        }

        private void Fill(Bitmap bm, int x, int y, Color new_clr)
        {
            Color old_color = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, new_clr);

            if (old_color == new_clr) return;

            while(pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();

                if(pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 &&  pt.Y < bm.Height - 1)
                {
                    validateFill(bm, pixel, pt.X - 1, pt.Y, old_color, new_clr);
                    validateFill(bm, pixel, pt.X, pt.Y - 1, old_color, new_clr);
                    validateFill(bm, pixel, pt.X + 1, pt.Y, old_color, new_clr);
                    validateFill(bm, pixel, pt.X, pt.Y + 1, old_color, new_clr);
                }
            }
        }

        public void SaveToFile()
        {
            var stf = new SaveFileDialog();
            stf.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if(stf.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = bitmapImage.Clone(new Rectangle(0, 0, pictureBox.Width, pictureBox.Height), bitmapImage.PixelFormat);
                btm.Save(stf.FileName, ImageFormat.Jpeg);
            }
        }

        public void OpenToFile()
        {
            var otf = new OpenFileDialog();
            otf.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";
            if (otf.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = new Bitmap(otf.FileName);
                pictureBox.Image = btm;
                pictureBox.Enabled = true;
            }
        }

        public void OpenFile()
        {
            var otf = new OpenFileDialog();
            otf.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";
            if (otf.ShowDialog() == DialogResult.OK)
            {
                Bitmap btm = new Bitmap(otf.FileName);
                pictureBox.Image = btm;
                pictureBox.Enabled = true;
            }
        }

        public void OnMousePictureBoxClick(Point location)
        {
            if (indexPaint == 6)
            {
                Point point = setPoint(pictureBox, location);
                Fill(bitmapImage, point.X, point.Y, color);
            }
        }

        public void OnMousePictureBox2Click(Point location)
        {
            Point point = setPoint(pictureBox2, location);
            pictureBox3.BackColor = ((Bitmap)pictureBox2.Image).GetPixel(point.X, point.Y);
            color = pictureBox3.BackColor;
            penPaint.Color = pictureBox3.BackColor;
        }

        public void OnMouseDown(Point location, int x, int y)
        {
            isPaint = true;
            py = location;

            cX = x;
            cY = y;
        }

        public void OnMouseMove(Point location, int x, int y)
        {
            if (isPaint)
            {
                if (indexPaint == 1)
                {
                    px = location;
                    graphicsEngine.DrawLine(penPaint, px, py);
                    py = px;
                }
                if (indexPaint == 2)
                {
                    px = location;
                    graphicsEngine.DrawLine(erasePaint, py, px);
                    py = px;
                }
            }
            pictureBox.Refresh();

            this.x = x;
            this.y = y;
            sX = x - cX;
            sY = y - cY;
        }

        public void OnMouseUp(int x, int y)
        {
            isPaint = false;

            sX = this.x - cX;
            sY = this.y - cY;

            if (indexPaint == 3)
            {
                graphicsEngine.DrawEllipse(penPaint, cX, cY, sX, sY);
            }
            if (indexPaint == 4)
            {
                graphicsEngine.DrawRectangle(penPaint, cX, cY, sX, sY);
            }
            if (indexPaint == 5)
            {
                graphicsEngine.DrawLine(penPaint, cX, cY, x, y);
            }
        }
    }
}
