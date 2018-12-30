namespace DCafeKiosk
{
    partial class FormMain
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
            this.panelFormLayer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelFormLayer
            // 
            this.panelFormLayer.BackColor = System.Drawing.Color.White;
            this.panelFormLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormLayer.Location = new System.Drawing.Point(0, 0);
            this.panelFormLayer.Name = "panelFormLayer";
            this.panelFormLayer.Size = new System.Drawing.Size(1920, 1080);
            this.panelFormLayer.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.panelFormLayer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormLayer;
    }
}