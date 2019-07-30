using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //HImage img = new HImage("1.bmp");
        private void Form1_Load(object sender, EventArgs e)
        {
            //imgBox1.Image = img;

            //HRegion reg = new HRegion(50d, 50d, 10);
            //imgBox1.Regions.Add(reg);

            //HRegion reg1 = new HRegion(100d, 100d, 10);
            //imgBox1.Regions.Add(reg1);
            //imgBox1.HalconWindow.SetColor("red");
            ////imgBox1.HalconWindow.SetDraw("margin");
            //imgBox1.DispImageFit();
            //Bitmap b = new Bitmap("1.bmp");
            //wImgBox1.Image = b;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.bmp)|*.bmp|(*.jpg)|*.jpg|(ALL)|*.*";

            if (ofd.ShowDialog()== DialogResult.OK)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                HImage img = new HImage(ofd.FileName);
                imgBox1.Regions.Clear();
                imgBox1.Image = img;
                imgBox1.DispImageFit();
                sw.Stop();

                Bitmap b = new Bitmap(ofd.FileName);
                wImgBox1.Image = b;
                wImgBox1.Refresh();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }

            //img = new HImage("1.jpg");
            //imgBox1.Regions.Clear();
            //imgBox1.Image = img;
            //imgBox1.DispImageFit();

        }
       
      
    }
}
