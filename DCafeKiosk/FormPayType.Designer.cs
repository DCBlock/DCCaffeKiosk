namespace DCafeKiosk
{
    partial class FormPayType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPayType));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ucPayTypeButton_UserUsageHistoryInquiry = new DCafeKiosk.UCPayTypeButton2();
            this.ucPayTypeButton_OderCancellation = new DCafeKiosk.UCPayTypeButton2();
            this.ucPayTypeButton_CustomerPayment = new DCafeKiosk.UCPayTypeButton2();
            this.ucPayTypeButton_DigicapTokenPayment = new DCafeKiosk.UCPayTypeButton2();
            this.ucPayTypeButton_MonthlyDeduction = new DCafeKiosk.UCPayTypeButton2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(482, 648);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
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
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1854, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ver 1.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(43, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(389, 29);
            this.label5.TabIndex = 49;
            this.label5.Text = "DigiCAP Campus Caffe (기능 선택)";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(483, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(900, 90);
            this.label1.TabIndex = 20;
            this.label1.Text = "직원 전용 카페 안내";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(483, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(900, 76);
            this.label2.TabIndex = 21;
            this.label2.Text = "DigiCAP과 Covision 직원만 이용 가능합니다.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(483, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(900, 26);
            this.label4.TabIndex = 22;
            this.label4.Text = "copyrightⓒ2019 All rights reserved by bojung crew.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPayTypeButton_UserUsageHistoryInquiry
            // 
            this.ucPayTypeButton_UserUsageHistoryInquiry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(179)))), ((int)(((byte)(224)))));
            this.ucPayTypeButton_UserUsageHistoryInquiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucPayTypeButton_UserUsageHistoryInquiry.ForeColor = System.Drawing.Color.White;
            this.ucPayTypeButton_UserUsageHistoryInquiry.Location = new System.Drawing.Point(1082, 648);
            this.ucPayTypeButton_UserUsageHistoryInquiry.Name = "ucPayTypeButton_UserUsageHistoryInquiry";
            this.ucPayTypeButton_UserUsageHistoryInquiry.Size = new System.Drawing.Size(300, 300);
            this.ucPayTypeButton_UserUsageHistoryInquiry.TabIndex = 18;
            this.ucPayTypeButton_UserUsageHistoryInquiry.XActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(199)))), ((int)(((byte)(244)))));
            this.ucPayTypeButton_UserUsageHistoryInquiry.XActiveForeColor = System.Drawing.Color.Black;
            this.ucPayTypeButton_UserUsageHistoryInquiry.XIdleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(179)))), ((int)(((byte)(224)))));
            this.ucPayTypeButton_UserUsageHistoryInquiry.XIdleForeColor = System.Drawing.Color.White;
            this.ucPayTypeButton_UserUsageHistoryInquiry.XSubTitle = "직원 카드 필요\n당월 사용 내역 조회";
            this.ucPayTypeButton_UserUsageHistoryInquiry.XTitle = "이용 내역 조회";
            this.ucPayTypeButton_UserUsageHistoryInquiry.Click += new System.EventHandler(this.ucPayTypeButton_UserUsageHistoryInquiry_Click);
            // 
            // ucPayTypeButton_OderCancellation
            // 
            this.ucPayTypeButton_OderCancellation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(99)))), ((int)(((byte)(62)))));
            this.ucPayTypeButton_OderCancellation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucPayTypeButton_OderCancellation.ForeColor = System.Drawing.Color.White;
            this.ucPayTypeButton_OderCancellation.Location = new System.Drawing.Point(782, 648);
            this.ucPayTypeButton_OderCancellation.Name = "ucPayTypeButton_OderCancellation";
            this.ucPayTypeButton_OderCancellation.Size = new System.Drawing.Size(300, 300);
            this.ucPayTypeButton_OderCancellation.TabIndex = 17;
            this.ucPayTypeButton_OderCancellation.XActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(119)))), ((int)(((byte)(82)))));
            this.ucPayTypeButton_OderCancellation.XActiveForeColor = System.Drawing.Color.Black;
            this.ucPayTypeButton_OderCancellation.XIdleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(99)))), ((int)(((byte)(62)))));
            this.ucPayTypeButton_OderCancellation.XIdleForeColor = System.Drawing.Color.White;
            this.ucPayTypeButton_OderCancellation.XSubTitle = "직원 카드 필요\n주문 완료 후 30분 이내 취소\n";
            this.ucPayTypeButton_OderCancellation.XTitle = "주문 취소";
            this.ucPayTypeButton_OderCancellation.Click += new System.EventHandler(this.ucPayTypeButton_OderCancellation_Click);
            // 
            // ucPayTypeButton_CustomerPayment
            // 
            this.ucPayTypeButton_CustomerPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(184)))), ((int)(((byte)(59)))));
            this.ucPayTypeButton_CustomerPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucPayTypeButton_CustomerPayment.ForeColor = System.Drawing.Color.White;
            this.ucPayTypeButton_CustomerPayment.Location = new System.Drawing.Point(782, 348);
            this.ucPayTypeButton_CustomerPayment.Name = "ucPayTypeButton_CustomerPayment";
            this.ucPayTypeButton_CustomerPayment.Size = new System.Drawing.Size(300, 300);
            this.ucPayTypeButton_CustomerPayment.TabIndex = 16;
            this.ucPayTypeButton_CustomerPayment.XActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(204)))), ((int)(((byte)(79)))));
            this.ucPayTypeButton_CustomerPayment.XActiveForeColor = System.Drawing.Color.Black;
            this.ucPayTypeButton_CustomerPayment.XIdleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(184)))), ((int)(((byte)(59)))));
            this.ucPayTypeButton_CustomerPayment.XIdleForeColor = System.Drawing.Color.White;
            this.ucPayTypeButton_CustomerPayment.XSubTitle = "디지캡 직원 카드만 가능";
            this.ucPayTypeButton_CustomerPayment.XTitle = "손님 결제";
            this.ucPayTypeButton_CustomerPayment.Click += new System.EventHandler(this.ucPayTypeButton_CustomerPayment_Click);
            // 
            // ucPayTypeButton_DigicapTokenPayment
            // 
            this.ucPayTypeButton_DigicapTokenPayment.BackColor = System.Drawing.Color.SeaGreen;
            this.ucPayTypeButton_DigicapTokenPayment.Enabled = false;
            this.ucPayTypeButton_DigicapTokenPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucPayTypeButton_DigicapTokenPayment.ForeColor = System.Drawing.Color.White;
            this.ucPayTypeButton_DigicapTokenPayment.Location = new System.Drawing.Point(1082, 348);
            this.ucPayTypeButton_DigicapTokenPayment.Name = "ucPayTypeButton_DigicapTokenPayment";
            this.ucPayTypeButton_DigicapTokenPayment.Size = new System.Drawing.Size(300, 300);
            this.ucPayTypeButton_DigicapTokenPayment.TabIndex = 15;
            this.ucPayTypeButton_DigicapTokenPayment.XActiveBackColor = System.Drawing.Color.MediumSeaGreen;
            this.ucPayTypeButton_DigicapTokenPayment.XActiveForeColor = System.Drawing.Color.Black;
            this.ucPayTypeButton_DigicapTokenPayment.XIdleBackColor = System.Drawing.Color.SeaGreen;
            this.ucPayTypeButton_DigicapTokenPayment.XIdleForeColor = System.Drawing.Color.White;
            this.ucPayTypeButton_DigicapTokenPayment.XSubTitle = "디지캡 가상화폐 지갑 전용";
            this.ucPayTypeButton_DigicapTokenPayment.XTitle = "가상화폐 결제";
            this.ucPayTypeButton_DigicapTokenPayment.Click += new System.EventHandler(this.ucPayTypeButton_DigicapTokenPayment_Click);
            // 
            // ucPayTypeButton_MonthlyDeduction
            // 
            this.ucPayTypeButton_MonthlyDeduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(179)))), ((int)(((byte)(224)))));
            this.ucPayTypeButton_MonthlyDeduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucPayTypeButton_MonthlyDeduction.ForeColor = System.Drawing.Color.White;
            this.ucPayTypeButton_MonthlyDeduction.Location = new System.Drawing.Point(482, 348);
            this.ucPayTypeButton_MonthlyDeduction.Name = "ucPayTypeButton_MonthlyDeduction";
            this.ucPayTypeButton_MonthlyDeduction.Size = new System.Drawing.Size(300, 300);
            this.ucPayTypeButton_MonthlyDeduction.TabIndex = 14;
            this.ucPayTypeButton_MonthlyDeduction.XActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(199)))), ((int)(((byte)(244)))));
            this.ucPayTypeButton_MonthlyDeduction.XActiveForeColor = System.Drawing.Color.Black;
            this.ucPayTypeButton_MonthlyDeduction.XIdleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(179)))), ((int)(((byte)(224)))));
            this.ucPayTypeButton_MonthlyDeduction.XIdleForeColor = System.Drawing.Color.White;
            this.ucPayTypeButton_MonthlyDeduction.XSubTitle = "직원 카드만 가능";
            this.ucPayTypeButton_MonthlyDeduction.XTitle = "월말 공제";
            this.ucPayTypeButton_MonthlyDeduction.Click += new System.EventHandler(this.ucPayTypeButton_MonthlyDeduction_Click);
            // 
            // FormPayType
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucPayTypeButton_UserUsageHistoryInquiry);
            this.Controls.Add(this.ucPayTypeButton_OderCancellation);
            this.Controls.Add(this.ucPayTypeButton_CustomerPayment);
            this.Controls.Add(this.ucPayTypeButton_DigicapTokenPayment);
            this.Controls.Add(this.ucPayTypeButton_MonthlyDeduction);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPayType";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private UCPayTypeButton2 ucPayTypeButton_MonthlyDeduction;
        private UCPayTypeButton2 ucPayTypeButton_DigicapTokenPayment;
        private UCPayTypeButton2 ucPayTypeButton_CustomerPayment;
        private UCPayTypeButton2 ucPayTypeButton_UserUsageHistoryInquiry;
        private UCPayTypeButton2 ucPayTypeButton_OderCancellation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

