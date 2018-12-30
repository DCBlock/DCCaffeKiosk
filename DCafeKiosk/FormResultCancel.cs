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

        public void ResetForm()
        {
            // 사용자 정보 출력
            this.label_UserInfo.Text = string.Format("{0} 님 ({1})", XName, XCompany);

            // {7777} 승인번호 주문이 취소 요청 되었습니다.
            this.label_ResultInfo.Text = string.Format("{0} 승인번호 주문이 취소 요청 되었습니다.", XReceiptId);
        }
        #endregion



        #region 'PROPERTIES'
        [Browsable(false)]
        public string XName { get; set; }       // 사용자명

        [Browsable(false)]
        public string XCompany { get; set; }    // 회사 이름

        [Browsable(false)]
        public string XReceiptId { get; set; }  // 취소한 영수증 ID
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
