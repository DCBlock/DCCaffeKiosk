using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCafeKiosk
{
    public partial class UCOrderItem : UserControl
    {
        /// <summary>
        /// 폼에서 콘트롤 제거 요청 이벤트
        /// </summary>
        public event EventHandler<EventArgs> OnRequestRemove;

        /// <summary>
        /// 플러스 버튼 클릭됨 이벤트
        /// </summary>
        public event EventHandler<EventArgs> OnPlusButtonClicked;

        /// <summary>
        /// 마이너스 버튼 클릭됨 이벤트
        /// </summary>
        public event EventHandler<EventArgs> OnMinusButtonClicked;

        //---------------------------------------------------------------------------

        /// <summary>
        /// 품목
        /// </summary>
        private String MenuNameKR = "Menu Item Name";
        public String XMenuNameKR
        {
            get { return MenuNameKR; }
            set { label_MenuNameKR.Text = MenuNameKR = value; Invalidate(); }
        }

        /// <summary>
        /// 용량
        /// </summary>
        private String MenuSize = "REGULAR";
        public String XMenuSize
        {
            get { return MenuSize; }
            set { label_MenuSize.Text = MenuSize = value; Invalidate(); }
        }

        /// <summary>
        /// 종류
        /// </summary>
        private String MenuType = "COLD";
        public String XMenuType
        {
            get { return MenuType; }
            set { label_MenuType.Text = MenuType = value; Invalidate(); }
        }

        /// <summary>
        /// 수량
        /// </summary>
        private int MenuAmount = 1;
        public int XMenuAmount
        {
            get { return MenuAmount; }
            set
            {
                MenuAmount = value;
                XMenuTotalAmount = XMenuUnitPrice * XMenuAmount;
                Invalidate();
            }
        }

        /// <summary>
        /// 단가
        /// </summary>
        private int MenuUnitPrice = 0;
        public int XMenuUnitPrice {
            get { return MenuUnitPrice; }
            set {
                MenuUnitPrice = value;
                label_MenuUnitPrice.Text = MenuUnitPrice.ToString();
                Invalidate();
            }
        }

        /// <summary>
        /// 합계 금액
        /// </summary>
        [Browsable(false)]
        public int XMenuTotalAmount { get; set; } = 0;

        /// <summary>
        /// 메뉴 버튼 객체
        /// </summary>
        [Browsable(false)]
        public UCMenuButton XMenuButtonObject { get; set; }

        //---------------------------------------------------------------------------


        /// <summary>
        /// 라벨 글자색
        /// </summary>
        private Color ForeTextColor = Color.Red;
        public Color XForeTextColor
        {
            get { return ForeTextColor; }
            set { ForeTextColor = value; Invalidate(); }
        }
        
        //---------------------------------------------------------------------------

        public UCOrderItem()
        {
            InitializeComponent();

            //
            Initialize();
        }

        private void Initialize()
        {
            // 테이블레이아웃 컬럼 사이즈 조정
            SuspendLayout();
            {
                this.tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent; // 품목
                this.tableLayoutPanel1.ColumnStyles[0].Width = 34;

                this.tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent; // 용량
                this.tableLayoutPanel1.ColumnStyles[1].Width = 22;

                this.tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Percent; // 종류
                this.tableLayoutPanel1.ColumnStyles[2].Width = 16;

                this.tableLayoutPanel1.ColumnStyles[3].SizeType = SizeType.Percent; // 단가
                this.tableLayoutPanel1.ColumnStyles[3].Width = 15;

                this.tableLayoutPanel1.ColumnStyles[4].SizeType = SizeType.Percent; // 수량
                this.tableLayoutPanel1.ColumnStyles[4].Width = 13;

                this.tableLayoutPanel1.ColumnStyles[5].SizeType = SizeType.Absolute;// 추가
                this.tableLayoutPanel1.ColumnStyles[5].Width = 60;

                this.tableLayoutPanel1.ColumnStyles[6].SizeType = SizeType.Absolute;// 빼기
                this.tableLayoutPanel1.ColumnStyles[6].Width = 60;
            }
            ResumeLayout();

            //
            this.tableLayoutPanel1.Invalidate();

            // 버튼 이벤트
            bunifuImageButton_Plus.Click += BunifuImageButton_Plus_Click;
            bunifuImageButton_Minus.Click += BunifuImageButton_Minus_Click;
        }

        /// <summary>
        /// 빼기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuImageButton_Minus_Click(object sender, EventArgs e)
        {
            XMenuAmount--;
            this.label_MenuAmount.Text = XMenuAmount.ToString();
            this.XMenuTotalAmount = XMenuUnitPrice * XMenuAmount;

            if(OnMinusButtonClicked != null)
                OnMinusButtonClicked(this, EventArgs.Empty);
        }
        
        /// <summary>
        /// 추가 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BunifuImageButton_Plus_Click(object sender, EventArgs e)
        {
            XMenuAmount++;
            this.label_MenuAmount.Text = XMenuAmount.ToString();
            this.XMenuTotalAmount = XMenuUnitPrice * XMenuAmount;

            if (OnPlusButtonClicked != null)
                OnPlusButtonClicked(this, EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 라벨 폰트 갱신
            label_MenuNameKR.Font = Font;
            label_MenuSize.Font = Font;
            label_MenuType.Font = Font;
            label_MenuAmount.Font = Font;

            // 라벨 텍스트 갱신
            label_MenuNameKR.Text = XMenuNameKR;
            label_MenuSize.Text = XMenuSize;
            label_MenuType.Text = XMenuType;
            label_MenuAmount.Text = XMenuAmount.ToString();

            // 라벨 글자색 갱신
            label_MenuNameKR.ForeColor =
                label_MenuSize.ForeColor =
                label_MenuType.ForeColor =
                label_MenuUnitPrice.ForeColor =
                label_MenuAmount.ForeColor = XForeTextColor;
        }
    }
}
