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
    public partial class FormMain : Form
    {
        /// <summary>
        /// 현재 결제 타입 저장
        /// </summary>
        private PAY_TYPE CurrentPayType;

        /// <summary>
        /// 월말 공제 페이지 순서 지정
        /// </summary>
        List<PAGES> ListMonthlyDeductionSequence = new List<PAGES>
            {
                PAGES.FormPayType,
                PAGES.FormRFRead,
                PAGES.FormMenuBoard,
                PAGES.FormOrderResult,
                PAGES.FormPayType,
            };

        /// <summary>
        /// 손님 결제 페이지 순서 지정
        /// </summary>
        List<PAGES> ListCustomerPayment = new List<PAGES>
            {
                PAGES.FormPayType,
                PAGES.FormRFRead,
                PAGES.FormMenuBoard,
                PAGES.FormOrderResult,
                PAGES.FormPayType,
            };

        public FormMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // 결제 방식 폼
            FormPayType _formPayType = new FormPayType();
            {
                _formPayType.OnSelectedPayType += OnSelectedPayType;
            }

            // RFID 폼
            FormRFRead _formRFRead = new FormRFRead();
            {
                _formRFRead.PageSuccess += OnPageSuccess;
                _formRFRead.PageCancle += OnPageCancle;
            }

            // 메뉴 폼
            FormMenuBoard _formMenuBoard = new FormMenuBoard();
            {
                _formMenuBoard.PageSuccess += OnPageSuccess;
                _formMenuBoard.PageCancle += OnPageCancle;

                //----------------------------------------
                //DataSet ds = APIController.API_GetMenus();
                //_formMenuBoard.CategoriesAndMenusDataset = ds;
                //_formMenuBoard.CategoriesAndMenusReload(ds);
            }

            // 결제 완료 폼
            FormOrderResult _formOrderResult = new FormOrderResult();
            {
                _formOrderResult.PageSuccess += OnPageSuccess;
                _formOrderResult.PageCancle += OnPageCancle;
            }

            // 판넬에 페이지 추가
            AddForms2Panel(_formPayType);
            AddForms2Panel(_formRFRead);
            AddForms2Panel(_formMenuBoard);
            AddForms2Panel(_formOrderResult);

            // 시작 페이지 보이기
            DisplayPage(nameof(FormPayType));
        }

        /// <summary>
        /// 결제 타입 선택 페이지 결과
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectedPayType(object sender, PayTypeEventArgs e)
        {
            // 현재 결제 방법 저장
            CurrentPayType = e.selected_paytype;

            // 결제 방법에 따른 다음 페이지 표시
            string nextPageName = NextPage(this.CurrentPayType, PAGES.FormPayType);
            DisplayPage(nextPageName);
        }

        /// <summary>
        /// MDIForm으로 하면 Mainform에 스크롤바가 생기고 타이틀바도 표시되어 보기 안좋다.
        /// Panel에 Form을 붙이는 것이 최선의 방법으로 판단됨.
        /// </summary>
        /// <param name="form"></param>
        private void AddForms2Panel(Form form)
        {
            form.TopLevel = false;
            panelFormLayer.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        /// <summary>
        /// 폼 객체 이름으로 조회 후 최상단으로 표시
        /// </summary>
        /// <param name="formName"></param>
        private void DisplayPage(string formName)
        {
            if (this.panelFormLayer.Controls.ContainsKey(formName)) {
                this.panelFormLayer.Controls[formName].BringToFront();
            }
        }

        /// <summary>
        /// 결제 모드에 따른 다음 페이지 이름 얻기
        /// </summary>
        private string NextPage(PAY_TYPE aPayType, PAGES aCurrentPages)
        {
            //string currentPageName = Enum.GetName(typeof(PAGES), aCurrentPages);
            int pageIdx = this.ListMonthlyDeductionSequence.IndexOf(aCurrentPages);

            string nextPageName;
            if (pageIdx++ <= this.ListMonthlyDeductionSequence.Count - 1)
                nextPageName = this.ListMonthlyDeductionSequence[pageIdx++].ToString();
            else
                nextPageName = string.Empty;

            return nextPageName;
        }

        /// <summary>
        /// 개별 페이지들의 성공 이벤트
        /// 다음 페이지 이동 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        ///================================================================================
        /// 월말 공제 프로세스 시작
        /// FormPayType -> FormRFReader -> FormMenuBoard -> FormOrderResult -> FormPayType
        /// 
        /// 손님 결제 프로세스 시작
        /// FormPayType -> FormRFReader -> FormMenuBoard -> FormOrderResult -> FormPayType
        /// 
        /// 주문 취소
        /// FormPayType -> FormRFReader -> FormKeyPad -> FormCancleResult -> FormPayType
        /// 
        /// 사용자 이용 내역 조회
        /// FormPayType -> FormRFReader -> FormInqueryResult -> FormPayType
        ///================================================================================
        private void OnPageSuccess(object sender, EventArgs e)
        {
            if((sender.GetType()).Name.CompareTo(PAGES.FormRFRead.ToString()) == 0)
            {
                //this.panelFormLayer.SuspendLayout();
                //{
                //    _formRFReader.Invoke(new MethodInvoker(_formRFReader.Hide));
                //    _formMenuBoard.Invoke(new MethodInvoker(_formMenuBoard.Show));
                //}
                //this.panelFormLayer.ResumeLayout();

                string nextPageName = NextPage(this.CurrentPayType, PAGES.FormRFRead);
                DisplayPage(nextPageName);
            }

            if ((sender.GetType()).Name.CompareTo(PAGES.FormMenuBoard.ToString()) == 0)
            {
                string nextPageName = NextPage(this.CurrentPayType, PAGES.FormMenuBoard);
                DisplayPage(nextPageName);
            }

            if ((sender.GetType()).Name.CompareTo(PAGES.FormOrderResult.ToString()) == 0)
            {
                string nextPageName = NextPage(this.CurrentPayType, PAGES.FormOrderResult);
                DisplayPage(nextPageName);
            }

            if ((sender.GetType()).Name.CompareTo(PAGES.FormKeyPad.ToString()) == 0)
            {

            }

            if ((sender.GetType()).Name.CompareTo(PAGES.FormCancleResult.ToString()) == 0)
            {

            }

            if ((sender.GetType()).Name.CompareTo(PAGES.FormInqueryResult.ToString()) == 0)
            {

            }
        }

        private void OnPageCancle(object sender, EventArgs e)
        {
            DisplayPage(PAGES.FormPayType.ToString());
        }
    }
}
