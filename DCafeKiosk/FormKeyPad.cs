using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCafeKiosk
{
    public partial class FormKeyPad : Form, IPage
    {
        /// <summary>
        /// 인터페이스
        /// </summary>
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

        public void InitializeForm()
        {
            // UI 초기화
            sbNumberDisplay.Clear();
            label_UserInfo.Text = "";
            label_Display.Text = "";

            // 사용자 정보
            this.label_UserInfo.Text = string.Format("{0} 님 ({1})", XName, XCompany);
        }
        #endregion
        //===============================================

        /// <summary>
        /// 프로퍼티
        /// </summary>
        #region 'properties'
        [Browsable(false)]
        public string XName { get; set; }

        [Browsable(false)]
        public string XCompany { get; set; }

        [Browsable(false)]
        public string XRfid { get; set; }
        #endregion

        private StringBuilder sbNumberDisplay = new StringBuilder();

        public FormKeyPad()
        {
            InitializeComponent();

            InitializeForm();

            button0.Click += KeypadNumber_Click;
            button1.Click += KeypadNumber_Click;
            button2.Click += KeypadNumber_Click;
            button3.Click += KeypadNumber_Click;
            button4.Click += KeypadNumber_Click;
            button5.Click += KeypadNumber_Click;
            button6.Click += KeypadNumber_Click;
            button7.Click += KeypadNumber_Click;
            button8.Click += KeypadNumber_Click;
            button9.Click += KeypadNumber_Click;

            buttonClear.Click += KeypadButtonClear_Click;
            buttonOk.Click += KeypadButtonOk_Click;
        }

        private void KeypadNumber_Click(object sender, EventArgs e)
        {
            string number = (sender as Button).Text;

            if (sbNumberDisplay.Length < 6) {
                sbNumberDisplay.Append(number);
                this.label_Display.Text = sbNumberDisplay.ToString();
            }
        }

        private void KeypadButtonOk_Click(object sender, EventArgs e)
        {
            // 취소 요청
            DTOPurchaseCancelResponse rsp = APIController.API_PatchPurchaseCancel(XRfid, this.label_Display.Text);

            // 완료
            if (rsp.code == 200) 
            {
                OnPageSuccess();
            }
            // 실패
            else
            {
                using (FormMessageBox dlg = new FormMessageBox())
                {
                    DialogResult dlgResult =
                        dlg.ShowDialog(@"취소 요청 처리되지 않았습니다.\n\r승인번호를 확인 후 다시 입력해주세요.", @"취소 요청 결과", CustomMessageBoxButtons.OK);

                    if (dlgResult == DialogResult.OK)
                        OnPageSuccess();
                }
            }
        }

        private void KeypadButtonClear_Click(object sender, EventArgs e)
        {
            int textLength = sbNumberDisplay.Length;

            if(sbNumberDisplay.Length > 0) {
                sbNumberDisplay.Remove(textLength - 1, 1);
                this.label_Display.Text = sbNumberDisplay.ToString();
            }
        }

        /// <summary>
        /// 취소 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            OnPageCancle();
        }
    }
}
