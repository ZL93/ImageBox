using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageBox
{
    public partial class WImgBox : PictureBox
    {
        public WImgBox()
        {
            InitializeComponent();
        }
        private Image img;

        public new Image Image
        {
            get { return img; }
            set
            {
                if (img != value && value !=null)
                {
                    img = value;
                    DispFit();
                    Refresh();
                }
            }
        }
        
        Rectangle dest = new Rectangle();
        Point p = new Point();
        float imgScale = 1;
        bool isMove = false;
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (img != null)
            {
                Graphics g = pe.Graphics;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.DrawImage(img, dest);
            }
            base.OnPaint(pe);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                p = new Point(e.X, e.Y);
                isMove = true;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isMove)
            {
                Point pn = new Point(e.X, e.Y);
                dest.X += e.X - p.X;
                dest.Y += e.Y - p.Y;
                p = new Point(e.X, e.Y);
                Refresh();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isMove = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                imgScale = 1.3f;

            }
            else
            {
                imgScale = 0.7f;
            }
            dest.X += (int)((e.X - dest.X) * (1 - imgScale));
            dest.Y += (int)((e.Y - dest.Y) * (1 - imgScale));
            dest.Width = (int)(dest.Width * imgScale);
            dest.Height = (int)(dest.Height * imgScale);
            Refresh();
            base.OnMouseWheel(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            DispFit();
            Refresh();
            base.OnMouseDoubleClick(e);
        }

        private void DispFit()
        {
            double ratio_win = (double)Width / (double)Height;
            double ratio_img = (double)img.Width / (double)img.Height;
            dest.X = 0;
            dest.Y = 0;
            if (ratio_win >= ratio_img)
            {
                dest.Width = (int)(Height * ((float)img.Width / (float)img.Height));
                dest.Height = Height;

            }
            else
            {
                dest.Width = Width;
                dest.Height = (int)(Width * ((float)img.Height / (float)img.Width));
            }
        }
    }
}
