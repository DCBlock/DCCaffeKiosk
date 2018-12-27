using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// for HID
using SharpLib.Win32;

namespace DCafeKiosk
{
    public partial class FormResultOrder : Form, IPage
    {
        #region 'IPage'
        public event EventHandler<EventArgs> PageSuccess;
        public event EventHandler<EventArgs> PageCancle;

        public void OnPageSuccess()
        {
            if (PageSuccess != null)
                PageSuccess(this, EventArgs.Empty);
        }

        public void OnPageCancle()
        {
            if (PageCancle != null)
                PageCancle(this, EventArgs.Empty);
        }
        #endregion

        #region 'PROPERTIES'
        public string UserInfoText {
            get
            {
                return this.label_UserInfoText.Text;
            }

            set
            {
                this.label_UserInfoText.Text = value;
                Invalidate();
            }
        }
        public string PayTypeInfoText {
            get
            {
                return this.label_PayTypeInfoText.Text;
            }
            set
            {
                this.label_PayTypeInfoText.Text = value;
                Invalidate();
            }
        }
        #endregion

        public FormResultOrder()
        {            
            InitializeComponent();

            bunifuFlatButton_cancle.Click += cancle_Click;
        }

        public void InitializeForm()
        {

        }

        private void cancle_Click(object sender, EventArgs e)
        {
            OnPageCancle();
        }
    }
}
