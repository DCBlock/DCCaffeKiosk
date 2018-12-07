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
    public partial class UCPayTypeButton2 : UserControl
    {
        #region 'properties'
        //---------------------------------------------------------------------------
        /// <summary>
        /// 결제 방식 텍스트
        /// </summary>
        private String title = "결제 방법";
        public String XTitle {
            get { return title; }
            set {
                title = value;
                title = title.Replace("\\n", "\n");
                title = title.Replace("\\r", "\r");
                Invalidate();
            }
        }

        /// <summary>
        /// 결제 방식 설명 텍스트
        /// </summary>
        private String subTitle = "부가 설명";
        public String XSubTitle {
            get { return subTitle; }
            set {
                subTitle = value;
                subTitle = subTitle.Replace("\\n", "\n");
                subTitle = subTitle.Replace("\\r", "\r");
                Invalidate();
            }
        }

        /// <summary>
        /// 기본 배경색
        /// </summary>
        private Color idleBackColor = Color.SeaGreen;
        public Color XIdleBackColor
        {
            get { return idleBackColor; }
            set { idleBackColor = value; Invalidate(); }
        }

        /// <summary>
        /// 기본 글자색
        /// </summary>
        private Color idleForeColor = Color.White;
        public Color XIdleForeColor
        {
            get { return idleForeColor; }
            set { idleForeColor = value; Invalidate(); }
        }

        /// <summary>
        /// 버튼 클릭 배경색
        /// </summary>
        private Color activeBackColor = Color.Blue;
        public Color XActiveBackColor {
            get { return activeBackColor; }
            set { activeBackColor = value; Invalidate(); }
        }

        /// <summary>
        /// 버튼 클릭 글자색
        /// </summary>
        private Color activeForeColor = Color.Black;
        public Color XActiveForeColor {
            get { return activeForeColor; }
            set { activeForeColor = value; Invalidate(); }
        }
        //---------------------------------------------------------------------------
        #endregion

        public UCPayTypeButton2()
        {
            InitializeComponent();
            this.ForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 배경색
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, Width, Height);

            // 텍스트 출력
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis;
            {
                // 지불 방법
                Font font1 = new Font("맑은고딕", 30, FontStyle.Bold);
                TextRenderer.DrawText(e.Graphics, XTitle, font1, new Point(Width + 3, (Height / 2) - 30), this.ForeColor, flags);
                Size titleSize = TextRenderer.MeasureText(XTitle, this.Font);

                // 부가 설명
                Font font2 = new Font("맑은고딕", 20, FontStyle.Bold);
                TextRenderer.DrawText(e.Graphics, XSubTitle, font2, new Point(Width + 3, (Height / 2) + titleSize.Height + 40), this.ForeColor, flags);
                
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.ForeColor = this.XActiveForeColor;
            this.BackColor = this.XActiveBackColor;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.ForeColor = this.XIdleForeColor;
            this.BackColor = this.XIdleBackColor;
        }
    }
}
