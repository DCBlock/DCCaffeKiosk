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
        public event EventHandler<EventArgs> PageCancel;

        public void OnPageSuccess()
        {
            if (PageSuccess != null)
                PageSuccess(this, EventArgs.Empty);
        }

        public void OnPageCancle()
        {
            if (PageCancel != null)
                PageCancel(this, EventArgs.Empty);
        }

        public void ResetForm()
        {
            label_UserInfoText.Text = string.Format("{0}님 ({1})", XName, XCompany);

            string strPayType = "";
            if (XPayType == PAY_TYPE.MonthlyDeduction)
                strPayType = "월말공제";
            else if(XPayType == PAY_TYPE.CustomerPayment)
                strPayType = "손님결제";
            label_PayTypeInfoText.Text = string.Format("{0}로 주문이 완료 되었습니다.", strPayType);
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

        [Browsable(false)]
        public string XName { get; set; }

        [Browsable(false)]
        public string XCompany { get; set; }

        [Browsable(false)]
        public PAY_TYPE XPayType { get; set; }
        #endregion

        public FormResultOrder()
        {            
            InitializeComponent();

            bunifuFlatButton_cancle.Click += cancle_Click;
        }

        private void cancle_Click(object sender, EventArgs e)
        {
            OnPageCancle();
        }
    }
}
