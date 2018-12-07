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
    public partial class FormMenuBoard : Form, IPageEventHandler
    {
        #region 'EVENT'
        //++++++++++++++++++++++++++++++++++++++++++++++++
        public event EventHandler<EventArgs> PageSuccess;
        public event EventHandler<EventArgs> PageCancle;

        public void OnPageSuccess() {
            if (PageSuccess != null)
                PageSuccess(this, EventArgs.Empty);
        }

        public void OnPageCancle() {
            if (PageCancle != null)
                PageCancle(this, EventArgs.Empty);
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++
        #endregion

        /// <summary>
        /// category name : flowlayoutpanel menus page 맵핑 저장
        /// </summary>
        private Dictionary<string, FlowLayoutPanel> dicMenuPages = new Dictionary<string, FlowLayoutPanel>();

        /// <summary>
        /// 현재 포커스된 카테고리
        /// </summary>
        private string CurrentCategoryName;
        
        #region 4Test Data
        /*
          "Coffee": 
          [
            {
                "category": 100,
                "code": 1,
                "name_en": "Americano",
                "name_kr": "아메리카노",
                "size":"REGULAR",
                "type":"BOTH",
                "price": 2500,
                "dc_digicap": 1500,
                "dc_covision": 0
             },
          ],
        */
        string[] Categories = { "Coffee", "Non-Coffee", "Bubble Tea", "Ade", "Smoothie", "Drink", "Tea" };

        string[,] Menus = { 
            { "상장 기념 무료 이벤트", "아메리카노", "REGULAR", "BOTH", "0", "1500", "0" }, 
            { "", "아메리카노", "REGULAR", "BOTH", "2500", "1500", "0" }, 
            { "", "라떼", "REGULAR", "BOTH", "3000", "2000", "0"}
        };
        #endregion



        public FormMenuBoard()
        {
            InitializeComponent();

            // 4TEST: 카테고리 버튼 추가
            Array.ForEach(Categories, t => AddCategory(t));

            // 4TEST: 카테고리 페이지에 메뉴 추가
            for (int i=0; i < Menus.GetLength(0); i++) {
                AddMenu("Coffee", Menus[i, 0], Menus[i, 1], Menus[i, 2], Menus[i, 3], Int32.Parse(Menus[i, 4]), Int32.Parse(Menus[i, 5]), Int32.Parse(Menus[i, 6]));
            }

            // 카테고리 추가하고 첫번째 항목에 포커스
            CurrentCategoryName = ((Bunifu.Framework.UI.BunifuThinButton2)this.flowLayoutPanel_Category.Controls[2]).ButtonText;
            dicMenuPages[CurrentCategoryName].BringToFront();

            // 주문 콘트롤 버튼 이벤트
            ucOrderItem1.OnMinusButtonClicked += UcOrderItem1_OnMinusButtonClicked;
            ucOrderItem1.OnPlusButtonClicked += UcOrderItem1_OnPlusButtonClicked;

            // 주문 카트 내역 초기화
            OrderCartClearAll();
        }

        #region '주문 카트 영역'
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
        /// NAME, SIZE, TYPE 조합으로 주문 카트 내역 추가
        /// CartOrderItem.Name = aItemName+aItemSize+aItemType 으로 CartOrderItem 객체 식별
        /// </summary>
        /// <param name="aMenuNameKR"></param>
        /// <param name="aMenuSize"></param>
        /// <param name="aMenuType"></param>
        /// <param name="aMenuUnitPrice"></param>
        /// <param name="aMenuAmount"></param>
        private void OrderCartAdd(string aMenuNameKR, string aMenuSize, string aMenuType, int aMenuUnitPrice, int aMenuAmount=1)
        {
            string keyName = string.Format("{0}{1}{2}", aMenuNameKR, aMenuSize, aMenuType);

            // 카트에 주문이 있으면 추가 하지 않음
            if (this.flowLayoutPanel_OrderCartLayout.Controls.ContainsKey(keyName) == true)
            {
                return;
            }

            // 타입이 "BOTH"이면 "메시지 박스 출력 선택
            if ((aMenuType.ToUpper()).CompareTo("BOTH") == 0)
            {

            }

            // 주문 추가
            UCOrderItem _OrderItem = new UCOrderItem();
            {
                _OrderItem.Name = keyName;

                //----------------------------------------------------------
                _OrderItem.BackColor = System.Drawing.Color.Transparent;
                _OrderItem.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                _OrderItem.Size = new System.Drawing.Size(539, 60);
                _OrderItem.XForeTextColor = System.Drawing.Color.White;
                
                //----------------------------------------------------------
                _OrderItem.XMenuNameKR = aMenuNameKR;
                _OrderItem.XMenuSize = aMenuSize;
                _OrderItem.XMenuType = aMenuType;
                _OrderItem.XMenuUnitPrice = aMenuUnitPrice;

                //----------------------------------------------------------
                _OrderItem.XMenuAmount = aMenuAmount;
                _OrderItem.XMenuTotalAmount = aMenuUnitPrice * aMenuAmount;
            }

            this.flowLayoutPanel_OrderCartLayout.Controls.Add(_OrderItem);
        }

        /// <summary>
        /// NAME, SIZE, TYPE 조합으로 주문 카트 내역 삭제
        /// CartOrderItem.Name = aItemName+aItemSize+aItemType 으로 CartOrderItem 객체 식별
        /// </summary>
        private void OrderCartRemove(string aItemName, string aItemSize, string aItemType)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcOrderItem1_OnPlusButtonClicked(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcOrderItem1_OnMinusButtonClicked(object sender, EventArgs e)
        {
            UCOrderItem obj = sender as UCOrderItem;

            if (obj.XMenuAmount <= 0)
                obj.Visible = false;
        }
        #endregion



        #region '카테고리 영역'
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
                _categoryButton.Font = new System.Drawing.Font("SpoqaHanSans-Regular", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                flp.Controls.Add(this.ucMenuButton1);
                flp.Controls.Add(this.ucMenuButton2);
                flp.Dock = System.Windows.Forms.DockStyle.Fill;                
                flp.Padding = new System.Windows.Forms.Padding(20, 20, 5, 5);

                //----------------------------------------------------------
                flp.Name = aCategoryName;
            }
            this.panel_pageLayout.Controls.Add(flp);
                        
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
        /// <param name="aEventName"></param>
        /// <param name="aMenuName"></param>
        /// <param name="aSize"></param>
        /// <param name="aType"></param>
        /// <param name="aPrice"></param>
        /// <param name="aDCDigicap"></param>
        /// <param name="aDCCovision"></param>
        private void AddMenu(
            string aCategoryName, 
            string aEventName, 
            string aMenuName, 
            string aSize, 
            string aType, 
            int aPrice, 
            int aDCDigicap, 
            int aDCCovision)
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
            OrderCartAdd(obj.XMenuNameKR, obj.XMenuSize, obj.XMenuType, obj.XMenuPrice);
        }

        /// <summary>
        /// 카테고리 페이지별 메뉴 지우기
        /// </summary>
        private void CategoryMenusClearAll()
        {
        }
        #endregion
    }
}
