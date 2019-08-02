namespace ImageBox
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wImgBox1 = new ImageBox.WImgBox();
            this.imgBox1 = new ImageBox.HImgBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wImgBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "打开图片";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(419, 257);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 118);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(452, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "联系我";
            // 
            // wImgBox1
            // 
            this.wImgBox1.BackColor = System.Drawing.Color.Black;
            this.wImgBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.wImgBox1.Image = null;
            this.wImgBox1.Location = new System.Drawing.Point(559, 0);
            this.wImgBox1.Name = "wImgBox1";
            this.wImgBox1.Size = new System.Drawing.Size(400, 404);
            this.wImgBox1.TabIndex = 13;
            this.wImgBox1.TabStop = false;
            // 
            // imgBox1
            // 
            this.imgBox1.BackColor = System.Drawing.Color.Black;
            this.imgBox1.BorderColor = System.Drawing.Color.Black;
            this.imgBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.imgBox1.Image = null;
            this.imgBox1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.imgBox1.Location = new System.Drawing.Point(0, 0);
            this.imgBox1.Margin = new System.Windows.Forms.Padding(2);
            this.imgBox1.Name = "imgBox1";
            this.imgBox1.Regions = ((System.Collections.Generic.List<HalconDotNet.HRegion>)(resources.GetObject("imgBox1.Regions")));
            this.imgBox1.Size = new System.Drawing.Size(400, 404);
            this.imgBox1.TabIndex = 1;
            this.imgBox1.WindowSize = new System.Drawing.Size(400, 404);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.wImgBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imgBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wImgBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private HImgBox imgBox1;
        private System.Windows.Forms.Button button1;
        private WImgBox wImgBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

