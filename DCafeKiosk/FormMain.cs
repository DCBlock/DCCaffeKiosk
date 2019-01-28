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
        //========================================
        /// <summary>
        /// 월말 공제 페이지 순서 지정
        /// </summary>
        List<PAGES> ListMonthlyDeductionSequence = new List<PAGES>
            {
                PAGES.FormPayType,
                PAGES.FormRFRead,
                PAGES.FormMenuBoard,
                PAGES.FormResultOrder,
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
                PAGES.FormResultOrder,
                PAGES.FormPayType,
            };

        /// <summary>
        /// 주문 취소 페이지 순서 지정
        /// </summary>
        List<PAGES> ListOderCancellation = new List<PAGES>
            {
                PAGES.FormPayType,
                PAGES.FormRFRead,
                PAGES.FormKeyPad,
                PAGES.FormResultCancel,
                PAGES.FormPayType,
            };

        /// <summary>
        /// 사용자 내역 조회 페이지 순서 지정
        /// </summary>
        List<PAGES> ListUserUsageHistoryInquiry = new List<PAGES>
            {
                PAGES.FormPayType,
                PAGES.FormRFRead,
                PAGES.FormResultInquery,
            };


        //========================================
        /// <summary>
        /// 현재 결제 타입
        /// </summary>
        private PAY_TYPE    mCurrentPayType;

        /// <summary>
        /// RFID 정보
        /// </summary>
        string      mRFID;
        string      mName;
        string      mCompany;
        int         mReceiptId;

        /// <summary>
        /// 메뉴 정보
        /// </summary>
        DTOGetMenusResponse mCategoryMenus;

        /// <summary>
        /// 화면
        /// </summary>
        FormPayType         mFormPayType;
        FormRFRead          mFormRFRead;
        FormMenuBoard       mFormMenuBoard;
        FormResultOrder     mFormResultOrder;
        FormResultCancel    mFormResultCancel;
        FormResultInquery   mFormResultInquery;
        FormKeyPad          mFormKeyPad;




        //========================================
        public FormMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // 결제 방식 폼
            mFormPayType = new FormPayType();
            {
                mFormPayType.OnSelectedPayType += OnSelectedPayType;
            }

            // RFID 폼
            mFormRFRead = new FormRFRead();
            {
                mFormRFRead.PageSuccess += OnPageSuccess;
                mFormRFRead.PageCancel += OnPageCancel;
            }

            // 메뉴 폼
            mFormMenuBoard = new FormMenuBoard();
            {
                mFormMenuBoard.PageSuccess += OnPageSuccess;
                mFormMenuBoard.PageCancel += OnPageCancel;

                //-----------------------------------
                // 메뉴가 변경되면 프로그램 재시작 필요
                // 메뉴는 프로그램 시작될때 설정됨
                //-----------------------------------
                mCategoryMenus = APIController.API_GetMenus();

                if (mCategoryMenus != null) {
                    mFormMenuBoard.XCategoriesAndMenusDictionary = mCategoryMenus.dicCategoryMenus;
                    mFormMenuBoard.ResetForm();
                }
                else {
                    MessageBox.Show("DCCaffe 서버로 부터 메뉴 정보를 가져오지 못했습니다.\n\r인터넷 연결을 점검한 후 다시 실행해야 합니다.", "문제 보고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.ExitThread();
                    Environment.Exit(0);
                    return;
                }
            }

            // 결제 완료 폼
            mFormResultOrder = new FormResultOrder();
            {
                mFormResultOrder.PageSuccess += OnPageSuccess;
                mFormResultOrder.PageCancel += OnPageCancel;
            }

            // 취소 키패드 폼
            mFormKeyPad = new FormKeyPad();
            {
                mFormKeyPad.PageSuccess += OnPageSuccess;
                mFormKeyPad.PageCancel += OnPageCancel;
            }

            // 취소 완료 폼
            mFormResultCancel = new FormResultCancel();
            {
                mFormResultCancel.PageSuccess += OnPageSuccess;
                mFormResultCancel.PageCancel += OnPageCancel;
            }

            // 내역 조회 완료 폼
            mFormResultInquery = new FormResultInquery();
            {
                mFormResultInquery.PageSuccess += OnPageSuccess;
                mFormResultInquery.PageCancel += OnPageCancel;
            }

            // 판넬에 페이지 추가
            AddForms2Panel(mFormPayType);
            AddForms2Panel(mFormRFRead);
            AddForms2Panel(mFormMenuBoard);
            AddForms2Panel(mFormResultOrder);
            AddForms2Panel(mFormKeyPad);
            AddForms2Panel(mFormResultCancel);
            AddForms2Panel(mFormResultInquery);

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
            mCurrentPayType = e.selected_paytype;

            // 결제 방법에 따른 다음 페이지 표시
            string nextPageName = NextPage(this.mCurrentPayType, PAGES.FormPayType);
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
            if (this.panelFormLayer.Controls.ContainsKey(formName))
            {
                this.panelFormLayer.Controls[formName].BringToFront();
                (this.panelFormLayer.Controls[formName] as IPage).ResetForm();
            }
        }

        /// <summary>
        /// 결제 모드에 따른 다음 페이지 이름 얻기
        /// </summary>
        private string NextPage(PAY_TYPE aPayType, PAGES aCurrentPages)
        {
            string nextPageName = string.Empty;

            switch (mCurrentPayType)
            {
                case PAY_TYPE.MonthlyDeduction:
                    {                        
                        //string currentPageName = Enum.GetName(typeof(PAGES), aCurrentPages);
                        int pageIdx = this.ListMonthlyDeductionSequence.IndexOf(aCurrentPages);
                        if (pageIdx++ <= this.ListMonthlyDeductionSequence.Count - 1)
                            nextPageName = this.ListMonthlyDeductionSequence[pageIdx++].ToString();
                        else
                            nextPageName = string.Empty;
                    }
                    break;
                case PAY_TYPE.CustomerPayment:
                    {
                        int pageIdx = this.ListCustomerPayment.IndexOf(aCurrentPages);
                        if (pageIdx++ <= this.ListCustomerPayment.Count - 1)
                            nextPageName = this.ListCustomerPayment[pageIdx++].ToString();
                        else
                            nextPageName = string.Empty;
                    }
                    break;
                case PAY_TYPE.OderCancellation:
                    {
                        int pageIdx = this.ListOderCancellation.IndexOf(aCurrentPages);
                        if (pageIdx++ <= this.ListOderCancellation.Count - 1)
                            nextPageName = this.ListOderCancellation[pageIdx++].ToString();
                        else
                            nextPageName = string.Empty;
                    }
                    break;
                case PAY_TYPE.UserUsageHistoryInquiry:
                    {
                        int pageIdx = this.ListUserUsageHistoryInquiry.IndexOf(aCurrentPages);
                        if (pageIdx++ <= this.ListUserUsageHistoryInquiry.Count - 1)
                            nextPageName = this.ListUserUsageHistoryInquiry[pageIdx++].ToString();
                        else
                            nextPageName = string.Empty;
                    }
                    break;
            }

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
        /// FormPayType -> FormRFReader -> FormMenuBoard -> FormResultOrder -> FormPayType
        /// 
        /// 손님 결제 프로세스 시작
        /// FormPayType -> FormRFReader -> FormMenuBoard -> FormResultOrder -> FormPayType
        /// 
        /// 주문 취소
        /// FormPayType -> FormRFReader -> FormKeyPad -> FormResultCancle -> FormPayType
        /// 
        /// 사용자 이용 내역 조회
        /// FormPayType -> FormRFReader -> FormResultInquery -> FormPayType
        ///================================================================================
        private void OnPageSuccess(object sender, EventArgs e)
        {
            //------------------
            // from FormRFReader
            //------------------
            if ((sender.GetType()).Name.CompareTo(PAGES.FormRFRead.ToString()) == 0)
            {
                // 현재 사용자 인증 정보 임시 저장
                {
                    this.mRFID = mFormRFRead.XstrHashedRFid;
                    this.mName = mFormRFRead.XApiResponse.name;
                    this.mCompany = mFormRFRead.XApiResponse.company;
                    this.mReceiptId = mFormRFRead.XApiResponse.receipt_id; // new receipt id
                }
                
                // 다음 페이지 화면 보이기
                string nextPageName = NextPage(this.mCurrentPayType, PAGES.FormRFRead);
                {
                    if (nextPageName == PAGES.FormMenuBoard.ToString())
                    {
                        mFormMenuBoard.XCompany = mCompany;
                        mFormMenuBoard.XName = mName;
                        mFormMenuBoard.XPayType = mCurrentPayType;
                        mFormMenuBoard.XReceiptId = mReceiptId;
                        mFormMenuBoard.ResetForm();
                    }
                    else if (nextPageName == PAGES.FormKeyPad.ToString())
                    {
                        mFormKeyPad.XCompany = mCompany;
                        mFormKeyPad.XName = mName;
                        mFormKeyPad.XRfid = mRFID;
                        mFormKeyPad.ResetForm();
                    }
                    else if (nextPageName == PAGES.FormResultInquery.ToString())
                    {
                        mFormResultInquery.XCompany = mCompany;
                        mFormResultInquery.XName = mName;
                        mFormResultInquery.XReceiptId = mReceiptId;

                        //----------------------------------------------
                        // 사용자 사용내역 URI 가져와서 QRCod Image 만들기
                        //----------------------------------------------
                        DateTime afterDt = DateTime.Now;
                        DateTime beforeDt = new DateTime(afterDt.Year, afterDt.Month, 1);

                        long beforeTimestamp = Utilities.TimeStamp.getUnixTimeStamp(beforeDt);
                        long afterTimestamp = Utilities.TimeStamp.getUnixTimeStamp(afterDt);

                        //-------------------------------------------------
                        DTOPurchaseHistoryOnetimeURLResponse _rsp =
                            APIController.API_PostPurchaseHistoryOnetimeURL(mRFID, beforeTimestamp, afterTimestamp);

                        if (_rsp.code == 200)
                            mFormResultInquery.XBitmapQRCode = Utilities.QRCode.GetQRCodeBitmap(_rsp.uri);
                        else
                            mFormResultInquery.XBitmapQRCode = null;
                        //-------------------------------------------------

                        mFormResultInquery.ResetForm();
                    }
                }
                DisplayPage(nextPageName);
            }

            //--------------------
            // from FormMenuBoard
            //--------------------
            if ((sender.GetType()).Name.CompareTo(PAGES.FormMenuBoard.ToString()) == 0)
            {
                string nextPageName = NextPage(this.mCurrentPayType, PAGES.FormMenuBoard);
                {
                    mFormResultOrder.XCompany = mCompany;
                    mFormResultOrder.XName = mName;
                    mFormResultOrder.XPayType = mCurrentPayType;
                    mFormResultOrder.ResetForm();
                }
                DisplayPage(nextPageName);
            }

            //---------------------
            // from FormResultOrder
            //---------------------
            if ((sender.GetType()).Name.CompareTo(PAGES.FormResultOrder.ToString()) == 0)
            {
                string nextPageName = NextPage(this.mCurrentPayType, PAGES.FormResultOrder);
                DisplayPage(nextPageName);
            }

            //------------------
            // from FormKeyPad
            //------------------
            if ((sender.GetType()).Name.CompareTo(PAGES.FormKeyPad.ToString()) == 0)
            {
                string nextPageName = NextPage(this.mCurrentPayType, PAGES.FormKeyPad);
                {
                    mFormResultCancel.XCompany = mCompany;
                    mFormResultCancel.XName = mName;
                    mFormResultCancel.XReceiptId = mFormKeyPad.XApiResponse.receipt_id;
                    mFormResultCancel.XPurchasedDate = mFormKeyPad.XApiResponse.purchased_date;
                    mFormResultCancel.ResetForm();
                }
                DisplayPage(nextPageName);
            }

            //-----------------------
            // from FormResultCancel
            //-----------------------
            if ((sender.GetType()).Name.CompareTo(PAGES.FormResultCancel.ToString()) == 0)
            {
                // nothing ...
            }

            //------------------------
            // from FormResultInquery
            //------------------------
            if ((sender.GetType()).Name.CompareTo(PAGES.FormResultInquery.ToString()) == 0)
            {
                // nothing ...
            }
        }

        private void OnPageCancel(object sender, EventArgs e)
        {
            // 처음 화면으로 이동
            DisplayPage(PAGES.FormPayType.ToString());
        }

        /// <summary>
        /// 프린터 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!ReceiptController.Instance.ConnectToUSB()) // 영수증 프린터 연결 실패
            {
                using (FormMessageBox dlgPrint = new FormMessageBox())
                {
                    {
                        //dlgPrint.Left = 1430;
                        //dlgPrint.Top = this.Location.X + (ClientSize.Height / 2) - 100;
                        //dlgPrint.XColorTitle = Color.FromArgb(73, 156, 188);
                        dlgPrint.StartPosition = FormStartPosition.CenterParent;
                    }

                    DialogResult dlgPrintResult =
                        dlgPrint.ShowDialog(@"영수증 프린터를 점검해 주세요." + Environment.NewLine + "프린터 연결 실패", @"영수증 프린터 점검", CustomMessageBoxButtons.OK);

                    // 프린터 연결될 때까지 재시도
                    if (dlgPrintResult == DialogResult.OK)
                        this.FormMain_Load(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 프린터 종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReceiptController.Instance.PrinterClose();
        }
    }
}
