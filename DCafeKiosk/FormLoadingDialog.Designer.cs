namespace DCafeKiosk
{
    partial class FormLoadingDialog
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
            this.ucLoadingDialogBox1 = new DCafeKiosk.UCLoadingDialogBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SuspendLayout();
            // 
            // ucLoadingDialogBox1
            // 
            this.ucLoadingDialogBox1.BackColor = System.Drawing.Color.Black;
            this.ucLoadingDialogBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLoadingDialogBox1.Location = new System.Drawing.Point(0, 0);
            this.ucLoadingDialogBox1.Name = "ucLoadingDialogBox1";
            this.ucLoadingDialogBox1.Size = new System.Drawing.Size(418, 140);
            this.ucLoadingDialogBox1.TabIndex = 0;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // FormLoadingDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(418, 140);
            this.Controls.Add(this.ucLoadingDialogBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLoadingDialog";
            this.Text = "FormLoadingDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private UCLoadingDialogBox ucLoadingDialogBox1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}