namespace DCafeKiosk
{
    partial class FormRFRead
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRFRead));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNext = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnCancle = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnTestRF = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 49);
            this.panel1.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1842, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ver 1.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(43, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 30);
            this.label5.TabIndex = 49;
            this.label5.Text = "DigiCAP Campus Caffe";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(504, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(900, 101);
            this.label1.TabIndex = 20;
            this.label1.Text = "본인 확인";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("SpoqaHanSans-Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(442, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1000, 63);
            this.label2.TabIndex = 21;
            this.label2.Text = "직원 카드를 RF Reader에 태그해 주세요.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(600, 334);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 559);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.ActiveBorderThickness = 1;
            this.btnNext.ActiveCornerRadius = 20;
            this.btnNext.ActiveFillColor = System.Drawing.Color.Crimson;
            this.btnNext.ActiveForecolor = System.Drawing.Color.White;
            this.btnNext.ActiveLineColor = System.Drawing.Color.Crimson;
            this.btnNext.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.ButtonText = "Test Next";
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnNext.IdleBorderThickness = 1;
            this.btnNext.IdleCornerRadius = 15;
            this.btnNext.IdleFillColor = System.Drawing.Color.Transparent;
            this.btnNext.IdleForecolor = System.Drawing.Color.Crimson;
            this.btnNext.IdleLineColor = System.Drawing.Color.Crimson;
            this.btnNext.Location = new System.Drawing.Point(1707, 855);
            this.btnNext.Margin = new System.Windows.Forms.Padding(5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(181, 80);
            this.btnNext.TabIndex = 27;
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancle
            // 
            this.btnCancle.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(87)))));
            this.btnCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(87)))));
            this.btnCancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancle.BorderRadius = 7;
            this.btnCancle.ButtonText = "처음으로";
            this.btnCancle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancle.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancle.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancle.Iconimage = null;
            this.btnCancle.Iconimage_right = null;
            this.btnCancle.Iconimage_right_Selected = null;
            this.btnCancle.Iconimage_Selected = null;
            this.btnCancle.IconMarginLeft = 0;
            this.btnCancle.IconMarginRight = 0;
            this.btnCancle.IconRightVisible = true;
            this.btnCancle.IconRightZoom = 0D;
            this.btnCancle.IconVisible = true;
            this.btnCancle.IconZoom = 90D;
            this.btnCancle.IsTab = false;
            this.btnCancle.Location = new System.Drawing.Point(1707, 965);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(87)))));
            this.btnCancle.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(107)))));
            this.btnCancle.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCancle.selected = false;
            this.btnCancle.Size = new System.Drawing.Size(181, 70);
            this.btnCancle.TabIndex = 51;
            this.btnCancle.Text = "처음으로";
            this.btnCancle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancle.Textcolor = System.Drawing.Color.White;
            this.btnCancle.TextFont = new System.Drawing.Font("SpoqaHanSans-Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnTestRF
            // 
            this.btnTestRF.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(87)))));
            this.btnTestRF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(87)))));
            this.btnTestRF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTestRF.BorderRadius = 7;
            this.btnTestRF.ButtonText = "RFReader";
            this.btnTestRF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestRF.DisabledColor = System.Drawing.Color.Gray;
            this.btnTestRF.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestRF.Iconcolor = System.Drawing.Color.Transparent;
            this.btnTestRF.Iconimage = null;
            this.btnTestRF.Iconimage_right = null;
            this.btnTestRF.Iconimage_right_Selected = null;
            this.btnTestRF.Iconimage_Selected = null;
            this.btnTestRF.IconMarginLeft = 0;
            this.btnTestRF.IconMarginRight = 0;
            this.btnTestRF.IconRightVisible = true;
            this.btnTestRF.IconRightZoom = 0D;
            this.btnTestRF.IconVisible = true;
            this.btnTestRF.IconZoom = 90D;
            this.btnTestRF.IsTab = false;
            this.btnTestRF.Location = new System.Drawing.Point(1508, 965);
            this.btnTestRF.Name = "btnTestRF";
            this.btnTestRF.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(87)))));
            this.btnTestRF.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(107)))));
            this.btnTestRF.OnHoverTextColor = System.Drawing.Color.White;
            this.btnTestRF.selected = false;
            this.btnTestRF.Size = new System.Drawing.Size(181, 70);
            this.btnTestRF.TabIndex = 52;
            this.btnTestRF.Text = "RFReader";
            this.btnTestRF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTestRF.Textcolor = System.Drawing.Color.White;
            this.btnTestRF.TextFont = new System.Drawing.Font("SpoqaHanSans-Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTestRF.Click += new System.EventHandler(this.btnTestRF_Click_1);
            // 
            // FormRFRead
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1920, 1061);
            this.Controls.Add(this.btnTestRF);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRFRead";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnNext;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancle;
        private Bunifu.Framework.UI.BunifuFlatButton btnTestRF;
    }
}

