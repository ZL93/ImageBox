using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.Threading;

namespace ImageBox
{
    public partial class HImgBox : HalconDotNet.HWindowControl
    {
        public HImage Image { get; set; }
        public List<HRegion> Regions { get; set; }
        float imgscale = 1;
        Point oldP = new Point();
        public HImgBox()
        {
            InitializeComponent();
            Regions = new List<HRegion>();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int x0, y0, x1, y1;
            HalconWindow.GetPart(out x0, out y0, out x1, out y1);
            imgscale = (float)(x1 - x0) / (float)(Height);
            float px0 = y0 + e.X * imgscale;
            float py0 = x0 + e.Y * imgscale;
            imgscale = imgscale * (float)(1 - (float)e.Delta / 300f);
            imgscale = imgscale < 0.05f ? 0.05f : imgscale;
            imgscale = imgscale > 10f ? 10f : imgscale;

            float px1 = e.X * imgscale;
            float py1 = e.Y * imgscale;

            float offsetX = px0 - px1;
            float offsetY = py0 - py1;
            HalconWindow.SetPart((int)offsetY, (int)offsetX, (int)(Height * imgscale + offsetY), (int)(Width * imgscale + offsetX));
            DispObj();
            base.OnMouseWheel(e);
        }
        int row1, col1, row2, col2;
        bool _move = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                oldP = new Point(e.X, e.Y);
                HalconWindow.GetPart(out row1, out col1, out row2, out col2);
                imgscale = (float)(row2 - row1) / (float)(Height);
                _move = true;
            }
            if (e.Clicks == 2)
            {
                DispImageFit();
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _move)
            {
                int offsetX = (int)((oldP.X - e.X) * imgscale);
                int offsetY = (int)((oldP.Y - e.Y) * imgscale);
                
                HalconWindow.SetPart(row1 + offsetY, col1 + offsetX, row2 + offsetY, col2 + offsetX);
                DispObj();
               
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _move = false;
            base.OnMouseUp(e);
        }
        public void DispImageFit()
        {
            if (Image != null)
            {
                int hv_imageWidth, hv_imageHeight;
                Image.GetImageSize(out hv_imageWidth, out hv_imageHeight);
                double ratio_win = (double)WindowSize.Width / (double)WindowSize.Height;
                double ratio_img = (double)hv_imageWidth / (double)hv_imageHeight;

                int _beginRow, _begin_Col, _endRow, _endCol;

                if (ratio_win >= ratio_img)
                {
                    _beginRow = 0;
                    _endRow = hv_imageHeight - 1;
                    _begin_Col = (int)(-hv_imageWidth * (ratio_win / ratio_img - 1d) / 2d);
                    _endCol = (int)(hv_imageWidth + hv_imageWidth * (ratio_win / ratio_img - 1d) / 2d);
                }
                else
                {
                    _begin_Col = 0;
                    _endCol = hv_imageWidth - 1;
                    _beginRow = (int)(-hv_imageHeight * (ratio_img / ratio_win - 1d) / 2d);
                    _endRow = (int)(hv_imageHeight + hv_imageHeight * (ratio_img / ratio_win - 1d) / 2d);
                }
                
                HalconWindow.SetPart(_beginRow, _begin_Col, _endRow, _endCol);
               
                DispObj();
            }
        }
        public void DispObj()
        {
            if (Image != null)
            {
                //解决移动图像闪烁问题
                HOperatorSet.SetSystem("flush_graphic", "false");
                HalconWindow.ClearWindow();
                HalconWindow.DispObj(Image);
                foreach (var item in Regions)
                {
                    HalconWindow.DispObj(item);
                }
                HOperatorSet.SetSystem("flush_graphic", "true");
                HObject emptyObject = new HObject();
                emptyObject.GenEmptyObj();
                HalconWindow.DispObj(emptyObject);
            }
        }
    }
}
