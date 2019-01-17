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
    public partial class FormMenuBoard : Form, IPage
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
            // 주문 카트 내역 초기화
            OrderCartClearAll();

            // 총액 초기화
            OrderCartUpdateTotalPrice();

            // 카테고리 메뉴 설정
            CategoriesAndMenusReload();

            // 사용자 정보
            this.label_UserInfo.Text = string.Format("{0} 님 ({1})", XName, XCompany);

            // 분리선 콘트롤 초기화
            this.bunifuSeparator_SelectedCategoryLine.LineThickness = 5;
            this.bunifuSeparator_SelectedCategoryLine.Location = new System.Drawing.Point(0, 98);
            this.bunifuSeparator_SelectedCategoryLine.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.bunifuSeparator_SelectedCategoryLine.Size = new System.Drawing.Size(168, 5);

            this.bunifuSeparator1.LineThickness = 5;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 112);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.bunifuSeparator1.Size = new System.Drawing.Size(1350, 5);
        }
        #endregion

        /// <summary>
        /// 프로퍼티
        /// </summary>
        #region 'properties'
        [Browsable(false)]
        public Dictionary<string, List<VOCategoryMenuList>> XCategoriesAndMenusDictionary { get; set; }

        [Browsable(false)]
        public string XName { get; set; }

        [Browsable(false)]
        public string XCompany { get; set; }

        [Browsable(false)]
        public int XReceiptId { get; set; }

        [Browsable(false)]
        public PAY_TYPE XPayType { get; set; }
        #endregion

        /// <summary>
        /// category name : flowlayoutpanel menus page 맵핑 저장
        /// </summary>
        private Dictionary<string, FlowLayoutPanel> dicMenuPages = new Dictionary<string, FlowLayoutPanel>();

        /// <summary>
        /// 현재 포커스된 카테고리
        /// </summary>
        private string CurrentCategoryName;

        public FormMenuBoard()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // 주문취소 / 주문완료
            bunifuFlatButton_Cancle.Click += OnCancleButton;
            bunifuFlatButton_Ok.Click += OnOkButton;

            // 초기화
            ResetForm();
        }

        #region '버튼 이벤트'
        /// <summary>
        /// 주문 취소 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancleButton(object sender, EventArgs e)
        {
            using (FormMessageBox dlg = new FormMessageBox())
            {
                {
                    dlg.Left = 1430;
                    dlg.Top = this.Location.X + (ClientSize.Height / 2) - 100;
                    dlg.XColorTitle = Color.FromArgb(235, 82, 87);
                }
                
                DialogResult dlgResult = 
                    dlg.ShowDialog(@"구매 절차를 취소하시겠습니까?", @"구매 중단", CustomMessageBoxButtons.YesNo);

                if(dlgResult == DialogResult.Yes)
                {
                    OnPageCancle();
                }
            }
        }

        /// <summary>
        /// 주문 완료 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOkButton(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------
            using (FormMessageBox dlg = new FormMessageBox())
            {
                {
                    dlg.Left = 1430;
                    dlg.Top = this.Location.X + (ClientSize.Height / 2) - 100;
                    dlg.XColorTitle = Color.FromArgb(73, 156, 188);
                }
                DialogResult dlgResult =
                    dlg.ShowDialog(@"구매를 완료 하시겠습니까?", @"최종 확인", CustomMessageBoxButtons.YesNo);

                if (dlgResult == DialogResult.Yes)
                {
                    //-----------------------------------------------------------------------------
                    // 영수증 프린터 연결 확인
                    //if (!ReceiptController.Instance.ConnectToUSB()) // 영수증 프린터 연결 실패
                    if(ReceiptController.Instance.GetStatus() != PRINT_STATUS.BXL_STS_CASHDRAWER_HIGH)
                    {
                        using (FormMessageBox dlgPrint = new FormMessageBox())
                        {
                            {
                                dlgPrint.Left = 1430;
                                dlgPrint.Top = this.Location.X + (ClientSize.Height / 2) - 100;
                                dlgPrint.XColorTitle = Color.FromArgb(73, 156, 188);
                            }

                            PRINT_STATUS printStatus = ReceiptController.Instance.GetStatus();

                            DialogResult dlgPrintResult =
                                dlgPrint.ShowDialog(@"영수증 프린터를 점검해 주세요." + Environment.NewLine + printStatus.ToString(), @"영수증 프린터 점검", CustomMessageBoxButtons.OK);
                        }
                        return;
                    }

                    //-----------------------------------------------------------------------------
                    // 구매 확정 API 호출
                    DTOPurchasesRequest _req = GetDTOPurchaseRequest();
                    DTOPurchasesResponse _rsp = APIController.API_PostPurchaseSuccess(XReceiptId.ToString(), _req);
                    //-----------------------------------------------------------------------------

                    if (_rsp.code == 200)
                    {
                        // 영수증 출력
                        string _strUserInfo = string.Format("{0}님 ({1})", XName, XCompany);
                        string _strPayType = "";
                        string _totalPayment = "0";
                        if (XPayType == PAY_TYPE.MonthlyDeduction)
                        {
                            _strPayType = "월말공제";

                            // 결제 총액 계산
                            _totalPayment = (_rsp.total_price - _rsp.total_dc_price).ToString("N0");
                        }                            
                        else if (XPayType == PAY_TYPE.CustomerPayment)
                        {
                            _strPayType = "손님결제";

                            // 손님결제일 경우, 영수증 결제 총액을 0원으로 표시
                            _totalPayment = "0"; 
                        }
                            

                        string _strCurrentDateTime = Utilities.DateTimeFormatString.getNowDateTimeFormatString();
                        List<VOPrintMenu> _printMenuList = GetPurchasePrintObject();

                        ReceiptController.Instance.Print(
                            _strUserInfo, 
                            XReceiptId.ToString(), 
                            _strPayType, 
                            _printMenuList, 
                            _strCurrentDateTime, 
                            _rsp.total_price.ToString("N0"),        // 구매 총액
                            _rsp.total_dc_price.ToString("N0"),     // 할인 총액
                            _totalPayment                           // 결제 총액
                            );

                        // 완료
                        OnPageSuccess();
                    }
                    else
                    {
                        //-------------------------------------------------------------------------
                        using (FormMessageBox dlg1 = new FormMessageBox())
                        {
                            {
                                dlg1.Left = 1430;
                                dlg1.Top = this.Location.X + (ClientSize.Height / 2) - 100;
                                dlg1.XColorTitle = Color.FromArgb(73, 156, 188);
                            }
                            DialogResult dlgResult1 =
                                dlg.ShowDialog(@"구매 처리를 완료하지 못했습니다."+ Environment.NewLine + _rsp.reason, @"구매 확정 처리 결과", CustomMessageBoxButtons.OK);
                        }//using
                    }                    
                }
            }//using
        }
        #endregion

        /// <summary>
        /// API 전달용 DTOPurchasesRequest 객체 데이터 만들기
        /// </summary>
        /// <returns></returns>
        private DTOPurchasesRequest GetDTOPurchaseRequest()
        {
            //-------------------------------------------------------------------------------------
            DTOPurchasesRequest _req = new DTOPurchasesRequest();
            _req.purchase_type = (int)XPayType;
            _req.purchases = new List<VOMenu>();

            //-------------------------------------------------------------------------------------
            int count = this.flowLayoutPanel_OrderCartLayout.Controls.Count;
            for (int index = 1; index < count; index++)
            {
                UCOrderItem _obj = this.flowLayoutPanel_OrderCartLayout.Controls[index] as UCOrderItem;

                //---------------------------------------------------------------------------------
                VOMenu _menu = new VOMenu();
                {
                    _menu.category = _obj.XMenuButtonObject.XCategoryCode;
                    _menu.code = _obj.XMenuButtonObject.XMenuCode;
                    _menu.price = _obj.XMenuButtonObject.XMenuPrice;
                    _menu.type = _obj.XMenuType;
                    _menu.size = _obj.XMenuButtonObject.XMenuSize;
                    _menu.count = _obj.XMenuAmount;
                }
                _req.purchases.Add(_menu);
            }
            return _req;
        }

        private List<VOPrintMenu> GetPurchasePrintObject()
        {
            // 영수증 출력 데이터 객체
            //List<VOPrintList> list = new List<VOPrintList>
            //{
            //    new VOPrintList{
            //        name ="아메리카노",
            //        size ="Regular",
            //        type="Hot",
            //        amount="3"
            //    },
            //    new VOPrintList{
            //        name ="아메리카노",
            //        size ="Regular",
            //        type="Iced",
            //        amount="2"
            //    },
            //    new VOPrintList{
            //        name ="까페라떼",
            //        size ="Regular",
            //        type="Hot",
            //        amount="1"
            //    },
            //};

            List<VOPrintMenu> list = new List<VOPrintMenu>();

            //-------------------------------------------------------------------------------------
            int count = this.flowLayoutPanel_OrderCartLayout.Controls.Count;
            for (int index = 1; index < count; index++)
            {
                UCOrderItem _obj = this.flowLayoutPanel_OrderCartLayout.Controls[index] as UCOrderItem;

                //---------------------------------------------------------------------------------
                VOPrintMenu menu = new VOPrintMenu();
                {
                    menu.name = _obj.XMenuNameKR;
                    menu.size = _obj.XMenuSize;
                    menu.type = _obj.XMenuType;
                    menu.amount = _obj.XMenuAmount.ToString();
                }
                list.Add(menu);
            }

            return list;
        }

        /// <summary>
        /// 메뉴를 초기화하고 다시 생성
        /// </summary>
        private void CategoriesAndMenusReload()
        {
            // 메뉴 데이터 설정 초기화
            CategoriesAndMenusClearAll();

            // 
            if (this.XCategoriesAndMenusDictionary == null)
                return;

            int category_cnt = XCategoriesAndMenusDictionary.Count;

            for (int i = 0; i < category_cnt; i++)
            {
                // Add categories
                AddCategory(XCategoriesAndMenusDictionary.ElementAt(i).Key);

                //-----------------------------------
                {
                    // Add menus
                    foreach (VOCategoryMenuList dr in XCategoriesAndMenusDictionary.ElementAt(i).Value)
                    {
                        /*
                        'Coffee':[
                          {
                              "category": 100,
                              "code": 1,
                              "name_en": "americano",
                              "name_kr": "아메리카노",
                              "price": 2500,
                              "type": "HOT",
                              "size": "REGULAR",
                              "event_name": "",
                              "discounts": {
                                "digicap": 1000,
                                "covision": 0
                              }
                          },
                        */

                        AddMenu(
                            // category name
                            XCategoriesAndMenusDictionary.ElementAt(i).Key,
                            dr.category,
                            dr.code,
                            dr.event_name,
                            dr.name_kr,
                            dr.size,
                            dr.type,
                            dr.price,
                            dr.discounts
                            );
                        //----------------------------------
                    }
                }
            }

            //
            // 카테고리 추가하고 첫번째 항목에 포커스
            if(this.flowLayoutPanel_Category.Controls.Count > 0)
                CurrentCategoryName = ((Bunifu.Framework.UI.BunifuThinButton2)this.flowLayoutPanel_Category.Controls[0]).ButtonText;

            if (dicMenuPages.Count > 0)
                dicMenuPages[CurrentCategoryName].BringToFront();
        }
               


        #region '주문 카트 추가/삭제 영역'        
        /// <summary>
        /// 주문 내역 전체 지우기
        /// </summary>
        private void OrderCartClearAll()
        {
            int count = this.flowLayoutPanel_OrderCartLayout.Controls.Count;

            // UCOrderItem 객체만 제거
            for(int index = 1; index < count; index++ )
            {
                UCOrderItem obj = this.flowLayoutPanel_OrderCartLayout.Controls[1] as UCOrderItem;
                this.flowLayoutPanel_OrderCartLayout.Controls.RemoveAt(1);
                obj.Dispose();
            }
        }

        /// <summary>
        /// NAME, SIZE, TYPE 조합으로 주문 카트 내역 삭제
        /// CartOrderItem.Name = aItemName+aItemSize+aItemType 으로 CartOrderItem 객체 식별
        /// </summary>
        private void OrderCartRemove(string aMenuNameKR, string aMenuSize, string aMenuType)
        {
            string keyName = string.Format("{0}{1}{2}", aMenuNameKR, aMenuSize, aMenuType);

            UCOrderItem obj = this.flowLayoutPanel_OrderCartLayout.Controls[keyName] as UCOrderItem;
            this.flowLayoutPanel_OrderCartLayout.Controls.RemoveByKey(keyName);
            obj.Dispose();
        }

        /// <summary>
        /// 구매 목록의 총액을 계산한다.
        /// </summary>
        private void OrderCartUpdateTotalPrice()
        {
            int _totalPrice = 0;

            int count = this.flowLayoutPanel_OrderCartLayout.Controls.Count;

            // UCOrderItem 객체의 가격 합산
            for (int index = 1; index < count; index++)
            {
                UCOrderItem obj = this.flowLayoutPanel_OrderCartLayout.Controls[index] as UCOrderItem;
                _totalPrice += obj.XMenuTotalAmount;
            }
            
            this.label_TotalPrice.Text = string.Format("{0:n0} 원", _totalPrice); //or .ToString("N0");
        }


        /// <summary>
        /// NAME, SIZE, TYPE 조합으로 주문 카트 내역 추가
        /// CartOrderItem.Name = aItemName+aItemSize+aItemType 으로 CartOrderItem 객체 식별
        /// </summary>
        /// <param name="aMenuButtonObj"></param>
        /// <param name="aMenuNameKR"></param>
        /// <param name="aMenuSize"></param>
        /// <param name="aMenuType"></param>
        /// <param name="aMenuUnitPrice"></param>
        /// <param name="aMenuAmount"></param>
        private void OrderCartAdd(UCMenuButton aMenuButtonObj, string aMenuNameKR, string aMenuSize, string aMenuType, int aMenuUnitPrice, int aMenuAmount=1)
        {
            // 타입이 "BOTH"이면 "메시지 박스 출력 선택
            if ((aMenuType.ToUpper()).CompareTo("BOTH") == 0)
            {
                using (FormMessageBox dlg = new FormMessageBox())
                {
                    {
                        dlg.Left = 450;
                        dlg.Top = this.Location.X + (ClientSize.Height / 2) - 100;
                    }

                    DialogResult dlgResult = dlg.ShowDialog("추가 옵션을 선택하세요.", "추가 옵션 선택", CustomMessageBoxButtons.HotIced);
                    {
                        if (dlgResult == DialogResult.OK)
                        {
                            aMenuType = "HOT";
                        }
                        else if (dlgResult == DialogResult.Cancel)
                        {
                            aMenuType = "ICED";
                        }
                    }
                }
            }

            // 카트 콘트롤 이름
            string keyName = string.Format("{0}{1}{2}", aMenuNameKR, aMenuSize, aMenuType);

            // 카트에 주문이 있으면 추가 하지 않고, 주문 개수 증가 시킴
            if (this.flowLayoutPanel_OrderCartLayout.Controls.ContainsKey(keyName) == true)
            {
                UCOrderItem control = this.flowLayoutPanel_OrderCartLayout.Controls[keyName] as UCOrderItem;
                control.XMenuAmount++;

                // 총액 업데이트
                OrderCartUpdateTotalPrice();
                return;
            }

            // 주문 추가
            UCOrderItem _OrderItem = new UCOrderItem();
            {
                _OrderItem.Name = keyName;

                //----------------------------------------------------------
                _OrderItem.BackColor = System.Drawing.Color.Transparent;
                _OrderItem.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                _OrderItem.Size = new System.Drawing.Size(539, 50);
                _OrderItem.XForeTextColor = System.Drawing.Color.White;
                
                //----------------------------------------------------------
                _OrderItem.XMenuNameKR = aMenuNameKR;
                _OrderItem.XMenuSize = aMenuSize;
                _OrderItem.XMenuType = aMenuType;
                _OrderItem.XMenuUnitPrice = aMenuUnitPrice;

                //----------------------------------------------------------
                _OrderItem.XMenuAmount = aMenuAmount;
                _OrderItem.XMenuTotalAmount = aMenuUnitPrice * aMenuAmount;

                //----------------------------------------------------------
                _OrderItem.XMenuButtonObject = aMenuButtonObj;

                //----------------------------------------------------------
                _OrderItem.OnMinusButtonClicked += UcOrderItem_OnMinusButtonClicked;
                _OrderItem.OnPlusButtonClicked += UcOrderItem_OnPlusButtonClicked;
            }

            this.flowLayoutPanel_OrderCartLayout.Controls.Add(_OrderItem);

            // 총액 업데이트
            OrderCartUpdateTotalPrice();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcOrderItem_OnPlusButtonClicked(object sender, EventArgs e)
        {
            UCOrderItem obj = sender as UCOrderItem;

            // 총액 업데이트
            OrderCartUpdateTotalPrice();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcOrderItem_OnMinusButtonClicked(object sender, EventArgs e)
        {
            UCOrderItem obj = sender as UCOrderItem;

            if (obj.XMenuAmount <= 0)
            {
                OrderCartRemove(obj.XMenuNameKR, obj.XMenuSize, obj.XMenuType);
            }

            // 총액 업데이트
            OrderCartUpdateTotalPrice();
        }
        #endregion





        #region '카테고리 추가 & 메뉴버튼 추가 영역'
        /*
            +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            [flowLayoutPanel_Category]  Category Button을 flowLayoutPanel_Category에 동적 생성 추가
            [panel_MenuPageLayout]      Category별 Menus를 담을 FlowLayoutPanel을 panel_pageLayout에 동적 생성 추가
            [panel_MenuPageLayout]      
            +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        */

        /// <summary>
        /// 카테고리 버튼 추가
        /// </summary>
        /// <param name="aCategoryName"></param>
        private void AddCategory(string aCategoryName)
        {
            // 카테고리
            Bunifu.Framework.UI.BunifuThinButton2 _categoryButton = new Bunifu.Framework.UI.BunifuThinButton2();
            {
                _categoryButton.ActiveBorderThickness = 1;
                _categoryButton.ActiveCornerRadius = 1;
                _categoryButton.ActiveFillColor = System.Drawing.Color.Transparent;
                _categoryButton.ActiveForecolor = System.Drawing.Color.DodgerBlue;
                _categoryButton.ActiveLineColor = System.Drawing.Color.Transparent;
                _categoryButton.BackColor = System.Drawing.Color.White;                
                _categoryButton.Cursor = System.Windows.Forms.Cursors.Hand;
                _categoryButton.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                _categoryButton.ForeColor = System.Drawing.Color.SeaGreen;
                _categoryButton.IdleBorderThickness = 1;
                _categoryButton.IdleCornerRadius = 1;
                _categoryButton.IdleFillColor = System.Drawing.Color.Transparent;
                _categoryButton.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                _categoryButton.IdleLineColor = System.Drawing.Color.Transparent;
                _categoryButton.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
                _categoryButton.Size = new System.Drawing.Size(160, 50);
                _categoryButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                //----------------------------------------------------------
                _categoryButton.ButtonText = aCategoryName;
            }
            this.flowLayoutPanel_Category.Controls.Add(_categoryButton);
                        
            // 카테고리 : 메뉴 페이지 맵핑 생성
            FlowLayoutPanel flp = new FlowLayoutPanel();
            {
                flp.BackColor = System.Drawing.Color.White;
                flp.Dock = System.Windows.Forms.DockStyle.Fill;                
                flp.Padding = new System.Windows.Forms.Padding(20, 20, 5, 5);

                //----------------------------------------------------------
                flp.Name = aCategoryName;
            }
            this.panel_MenuPageLayout.Controls.Add(flp);
                        
            // 딕셔너리에 메뉴 페이지 저장
            dicMenuPages.Add(aCategoryName, flp);
                        
            // 버튼 이벤트
            _categoryButton.Click += _categoryButton_Click;
        }

        /// <summary>
        /// 카테고리 버튼들 클릭 이벤트 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _categoryButton_Click(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuThinButton2 _categoryButton = sender as Bunifu.Framework.UI.BunifuThinButton2;

            // 현재 카테고리 포커스
            this.CurrentCategoryName = _categoryButton.ButtonText;
                        
            // 선택 UI 포커스 언더라인 이동            
            Point pt = new Point(_categoryButton.Location.X, this.bunifuSeparator_SelectedCategoryLine.Location.Y);
            Size sz = new Size(_categoryButton.Width, this.bunifuSeparator_SelectedCategoryLine.Height);
            {
                this.bunifuSeparator_SelectedCategoryLine.Location = pt;
                this.bunifuSeparator_SelectedCategoryLine.Size = sz;
            }
                        
            // 선택된 카테고리 페이지 상단으로 표시            
            this.dicMenuPages[CurrentCategoryName].BringToFront();
        }

        /// <summary>
        /// 카테고리별 페이지에 메뉴 추가
        /// </summary>
        /// <param name="aCategoryName"></param>
        /// <param name="aCategoryCode"></param>
        /// <param name="aMenuCode"></param>
        /// <param name="aEventName"></param>
        /// <param name="aMenuName"></param>
        /// <param name="aSize"></param>
        /// <param name="aType"></param>
        /// <param name="aPrice"></param>
        /// <param name="aDCDigicap"></param>
        /// <param name="aDCCovision"></param>
        private void AddMenu(
            string aCategoryName,
            int aCategoryCode,
            int aMenuCode,
            string aEventName, 
            string aMenuName, 
            string aSize, 
            string aType, 
            int aPrice, 
            //int aDCDigicap, 
            //int aDCCovision
            Dictionary<string, int> aDiscounts
            )

        {
            UCMenuButton _menuButton = new UCMenuButton();
            {
                _menuButton.BackColor = System.Drawing.Color.WhiteSmoke;
                _menuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                _menuButton.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                _menuButton.ForeColor = System.Drawing.Color.DimGray;
                _menuButton.Size = new System.Drawing.Size(250, 250);
                _menuButton.XBorderColor = System.Drawing.Color.Gainsboro;
                _menuButton.XOnHoverBackColor = System.Drawing.Color.DarkOrchid;

                //----------------------------------------------------------
                _menuButton.XCategoryCode = aCategoryCode;
                _menuButton.XMenuCode = aMenuCode;
                _menuButton.XEventName = aEventName;
                _menuButton.XMenuNameKR = aMenuName;
                _menuButton.XMenuNameEN = "Product Name";
                _menuButton.XMenuSize = aSize;
                _menuButton.XMenuType = aType;
                _menuButton.XMenuPrice = aPrice;
            }

            // 해당 카테고리 페이지에 메뉴 추가
            FlowLayoutPanel flp;
            this.dicMenuPages.TryGetValue(aCategoryName, out flp);
            flp.Controls.Add(_menuButton);

            // 클릭 이벤트
            _menuButton.Click += _menuButton_Click;
        }

        /// <summary>
        /// 카테고리 메뉴 버튼 클릭 이벤트 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _menuButton_Click(object sender, EventArgs e)
        {
            UCMenuButton obj = sender as UCMenuButton;
            OrderCartAdd(obj, obj.XMenuNameKR, obj.XMenuSize, obj.XMenuType, obj.XMenuPrice);
        }

        /// <summary>
        /// 동적 카테고리와 동적 메뉴 전체 제거하기
        /// </summary>
        private void CategoriesAndMenusClearAll()
        {
            // panel_MenuPageLayout > FlowLayoutPanel > UCMenuButton

            // 메뉴 동적 콘트롤 제거
            int categoryCount = this.panel_MenuPageLayout.Controls.Count;

            while (this.panel_MenuPageLayout.Controls.Count > 0)
            {
                while (this.panel_MenuPageLayout.Controls[0].Controls.Count > 0)
                {
                    UCMenuButton control = this.panel_MenuPageLayout.Controls[0].Controls[0] as UCMenuButton;
                    
                    // 메뉴 이벤트 제거
                    control.Click -= _menuButton_Click;

                    // 메뉴 객체 제거
                    this.panel_MenuPageLayout.Controls[0].Controls.RemoveAt(0);

                    // 메뉴 객체 릴리즈
                    control.Dispose();
                }

                FlowLayoutPanel flp = this.panel_MenuPageLayout.Controls[0] as FlowLayoutPanel;
                this.panel_MenuPageLayout.Controls.RemoveAt(0);
                flp.Dispose();
            }

            // 카테고리 동적 콘트롤 제거
            while(this.flowLayoutPanel_Category.Controls.Count > 0)
            {
                Control control = this.flowLayoutPanel_Category.Controls[0];

                // 카테고리 이벤트 제거
                control.Click -= _categoryButton_Click;

                // 카테고리 객체 제거
                this.flowLayoutPanel_Category.Controls.RemoveAt(0);

                // 카테고리 객체 릴리즈
                control.Dispose();
            }

            // 카테고리 페이지 맵핑 제거
            dicMenuPages.Clear();
        }
        #endregion
    }
}
