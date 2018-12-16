namespace DCafeKiosk
{
    partial class FormTest
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ucOrderTitle1 = new DCafeKiosk.UCOrderTitle();
            this.ucOrderItem1 = new DCafeKiosk.UCOrderItem();
            this.ucOrderItem2 = new DCafeKiosk.UCOrderItem();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ucOrderTitle1);
            this.flowLayoutPanel1.Controls.Add(this.ucOrderItem1);
            this.flowLayoutPanel1.Controls.Add(this.ucOrderItem2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(622, 183);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ucOrderTitle1
            // 
            this.ucOrderTitle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucOrderTitle1.Font = new System.Drawing.Font("SpoqaHanSans-Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucOrderTitle1.Location = new System.Drawing.Point(3, 3);
            this.ucOrderTitle1.Name = "ucOrderTitle1";
            this.ucOrderTitle1.Size = new System.Drawing.Size(618, 38);
            this.ucOrderTitle1.TabIndex = 0;
            // 
            // ucOrderItem1
            // 
            this.ucOrderItem1.BackColor = System.Drawing.Color.Transparent;
            this.ucOrderItem1.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucOrderItem1.Location = new System.Drawing.Point(3, 47);
            this.ucOrderItem1.Name = "ucOrderItem1";
            this.ucOrderItem1.Size = new System.Drawing.Size(618, 55);
            this.ucOrderItem1.TabIndex = 1;
            this.ucOrderItem1.XForeTextColor = System.Drawing.Color.Black;
            this.ucOrderItem1.XMenuAmount = 1;
            this.ucOrderItem1.XMenuButtonObject = null;
            this.ucOrderItem1.XMenuNameKR = "Menu Item Name";
            this.ucOrderItem1.XMenuSize = "Regular";
            this.ucOrderItem1.XMenuTotalAmount = 0;
            this.ucOrderItem1.XMenuType = "Cold";
            this.ucOrderItem1.XMenuUnitPrice = 0;
            // 
            // ucOrderItem2
            // 
            this.ucOrderItem2.BackColor = System.Drawing.Color.Transparent;
            this.ucOrderItem2.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucOrderItem2.Location = new System.Drawing.Point(3, 108);
            this.ucOrderItem2.Name = "ucOrderItem2";
            this.ucOrderItem2.Size = new System.Drawing.Size(618, 50);
            this.ucOrderItem2.TabIndex = 2;
            this.ucOrderItem2.XForeTextColor = System.Drawing.Color.Black;
            this.ucOrderItem2.XMenuAmount = 1;
            this.ucOrderItem2.XMenuButtonObject = null;
            this.ucOrderItem2.XMenuNameKR = "Menu Item Name";
            this.ucOrderItem2.XMenuSize = "Regular";
            this.ucOrderItem2.XMenuTotalAmount = 0;
            this.ucOrderItem2.XMenuType = "Cold";
            this.ucOrderItem2.XMenuUnitPrice = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "음료 타입 선택 다이얼로그";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 594);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UCOrderTitle ucOrderTitle1;
        private UCOrderItem ucOrderItem1;
        private UCOrderItem ucOrderItem2;
        private System.Windows.Forms.Button button1;
    }
}