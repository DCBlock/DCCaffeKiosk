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
    public partial class FormResultInquery : Form, IPage
    {
        /// <summary>
        /// 인터페이스
        /// </summary>
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

            // QRCode 이미지
            this.pictureBox_QRCode.Image = XBitmapQRCode;
        }
        #endregion



        /// <summary>
        /// 프로퍼티
        /// </summary>
        #region 'PROPERTIES'
        [Browsable(false)]
        public string XName { get; set; }               // 사용자명

        [Browsable(false)]
        public string XCompany { get; set; }            // 회사 이름

        [Browsable(false)]
        public int XReceiptId { get; set; }          // 취소한 영수증 ID

        [Browsable(false)]
        public Bitmap XBitmapQRCode { get; set; }       // QRCode 이미지
        #endregion



        public FormResultInquery()
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
