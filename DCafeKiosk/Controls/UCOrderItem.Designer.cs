namespace DCafeKiosk
{
    partial class UCOrderItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCOrderItem));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_MenuNameKR = new System.Windows.Forms.Label();
            this.label_MenuType = new System.Windows.Forms.Label();
            this.label_MenuSize = new System.Windows.Forms.Label();
            this.bunifuImageButton_Minus = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton_Plus = new Bunifu.Framework.UI.BunifuImageButton();
            this.label_MenuAmount = new System.Windows.Forms.Label();
            this.label_MenuUnitPrice = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Minus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Plus)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label_MenuNameKR, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_MenuType, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_MenuSize, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bunifuImageButton_Minus, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.bunifuImageButton_Plus, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_MenuAmount, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_MenuUnitPrice, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Gray;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 55);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label_MenuNameKR
            // 
            this.label_MenuNameKR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MenuNameKR.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_MenuNameKR.ForeColor = System.Drawing.Color.Gray;
            this.label_MenuNameKR.Location = new System.Drawing.Point(3, 0);
            this.label_MenuNameKR.Name = "label_MenuNameKR";
            this.label_MenuNameKR.Size = new System.Drawing.Size(147, 55);
            this.label_MenuNameKR.TabIndex = 9;
            this.label_MenuNameKR.Text = "아메리카노";
            this.label_MenuNameKR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_MenuType
            // 
            this.label_MenuType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MenuType.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_MenuType.ForeColor = System.Drawing.Color.Gray;
            this.label_MenuType.Location = new System.Drawing.Point(255, 0);
            this.label_MenuType.Name = "label_MenuType";
            this.label_MenuType.Size = new System.Drawing.Size(66, 55);
            this.label_MenuType.TabIndex = 1;
            this.label_MenuType.Text = "Hot";
            this.label_MenuType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_MenuSize
            // 
            this.label_MenuSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MenuSize.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_MenuSize.ForeColor = System.Drawing.Color.Gray;
            this.label_MenuSize.Location = new System.Drawing.Point(156, 0);
            this.label_MenuSize.Name = "label_MenuSize";
            this.label_MenuSize.Size = new System.Drawing.Size(93, 55);
            this.label_MenuSize.TabIndex = 6;
            this.label_MenuSize.Text = "Regular";
            this.label_MenuSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuImageButton_Minus
            // 
            this.bunifuImageButton_Minus.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton_Minus.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton_Minus.Image")));
            this.bunifuImageButton_Minus.ImageActive = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton_Minus.ImageActive")));
            this.bunifuImageButton_Minus.Location = new System.Drawing.Point(512, 3);
            this.bunifuImageButton_Minus.Name = "bunifuImageButton_Minus";
            this.bunifuImageButton_Minus.Size = new System.Drawing.Size(55, 49);
            this.bunifuImageButton_Minus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bunifuImageButton_Minus.TabIndex = 8;
            this.bunifuImageButton_Minus.TabStop = false;
            this.bunifuImageButton_Minus.Zoom = 10;
            // 
            // bunifuImageButton_Plus
            // 
            this.bunifuImageButton_Plus.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton_Plus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuImageButton_Plus.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton_Plus.Image")));
            this.bunifuImageButton_Plus.ImageActive = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton_Plus.ImageActive")));
            this.bunifuImageButton_Plus.Location = new System.Drawing.Point(452, 3);
            this.bunifuImageButton_Plus.Name = "bunifuImageButton_Plus";
            this.bunifuImageButton_Plus.Size = new System.Drawing.Size(54, 49);
            this.bunifuImageButton_Plus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bunifuImageButton_Plus.TabIndex = 7;
            this.bunifuImageButton_Plus.TabStop = false;
            this.bunifuImageButton_Plus.Zoom = 10;
            // 
            // label_MenuAmount
            // 
            this.label_MenuAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MenuAmount.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_MenuAmount.ForeColor = System.Drawing.Color.Gray;
            this.label_MenuAmount.Location = new System.Drawing.Point(394, 0);
            this.label_MenuAmount.Name = "label_MenuAmount";
            this.label_MenuAmount.Size = new System.Drawing.Size(52, 55);
            this.label_MenuAmount.TabIndex = 2;
            this.label_MenuAmount.Text = "1";
            this.label_MenuAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_MenuUnitPrice
            // 
            this.label_MenuUnitPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MenuUnitPrice.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_MenuUnitPrice.ForeColor = System.Drawing.Color.Gray;
            this.label_MenuUnitPrice.Location = new System.Drawing.Point(327, 0);
            this.label_MenuUnitPrice.Name = "label_MenuUnitPrice";
            this.label_MenuUnitPrice.Size = new System.Drawing.Size(61, 55);
            this.label_MenuUnitPrice.TabIndex = 2;
            this.label_MenuUnitPrice.Text = "2500";
            this.label_MenuUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCOrderItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "UCOrderItem";
            this.Size = new System.Drawing.Size(570, 55);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Minus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton_Plus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_MenuType;
        private System.Windows.Forms.Label label_MenuSize;
        private System.Windows.Forms.Label label_MenuAmount;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton_Plus;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton_Minus;
        private System.Windows.Forms.Label label_MenuNameKR;
        private System.Windows.Forms.Label label_MenuUnitPrice;
    }
}
