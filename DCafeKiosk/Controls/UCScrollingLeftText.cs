using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCafeKiosk
{
    public partial class UCScrollingLeftText : UserControl
    {
        #region 'export properties'
        private String scrollingText = "scrolling text ...";
        public String XScrollingText
        {
            get { return scrollingText; }
            set
            {
                scrollingText = value;
                Invalidate();
            }
        }
        #endregion

        private Timer timer { get; set; }

        //--------------------------------------------------

        public UCScrollingLeftText()
        {
            InitializeComponent();                        

            timer = new Timer();
            timer.Interval = 25;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            label1.Text = scrollingText;
            if (label1.Left < 0 && (Math.Abs(label1.Left) > label1.Width))
                label1.Left = this.Width;
            label1.Left -= 1;
        }
    }
}
