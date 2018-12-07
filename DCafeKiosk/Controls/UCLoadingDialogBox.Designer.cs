namespace DCafeKiosk
{
    partial class UCLoadingDialogBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ucCircleLoading1 = new NetmarbleGoldAttendance.UCCircleLoading();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SuspendLayout();
            // 
            // ucCircleLoading1
            // 
            this.ucCircleLoading1.BackColor = System.Drawing.Color.Transparent;
            this.ucCircleLoading1.Location = new System.Drawing.Point(37, 27);
            this.ucCircleLoading1.Margin = new System.Windows.Forms.Padding(1);
            this.ucCircleLoading1.Name = "ucCircleLoading1";
            this.ucCircleLoading1.Size = new System.Drawing.Size(90, 84);
            this.ucCircleLoading1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("NanumGothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(171, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 63);
            this.label1.TabIndex = 1;
            this.label1.Text = "요청 작업 확인중 입니다.\r\n\r\n잠시만 기다려 주세요.";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 4;
            this.bunifuElipse1.TargetControl = this;
            // 
            // UCLoadingDialogBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucCircleLoading1);
            this.Name = "UCLoadingDialogBox";
            this.Size = new System.Drawing.Size(435, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NetmarbleGoldAttendance.UCCircleLoading ucCircleLoading1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}
