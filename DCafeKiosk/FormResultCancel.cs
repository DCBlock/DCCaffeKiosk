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
    public partial class FormResultCancel : Form, IPage
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
            // 사용자 정보 출력
            this.label_UserInfo.Text = string.Format("{0} 님 ({1})", XName, XCompany);

            // 일자:{xxxxx}/승인번호:{xx} 주문이 취소 요청 되었습니다.
            this.label_ResultInfo.Text = string.Format("일자:{0} / 승인번호:{1} 주문이 취소 요청 되었습니다.", XPurchasedDate, XReceiptId);
        }
        #endregion



        #region 'PROPERTIES'
        [Browsable(false)]
        public string XName { get; set; }           // 사용자명

        [Browsable(false)]
        public string XCompany { get; set; }        // 회사 이름

        [Browsable(false)]
        public int XReceiptId { get; set; }         // 취소한 영수증 ID

        [Browsable(false)]
        public string XPurchasedDate { get; set; }  // 구매한 일자
        #endregion



        public FormResultCancel()
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
