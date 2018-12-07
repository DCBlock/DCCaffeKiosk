using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace DCafeKiosk
{
    public partial class UCMenuButtonVertical : UserControl
    {
        public UCMenuButtonVertical()
        {
            InitializeComponent();
            DoubleBuffered = true;

            this.BackColor = Color.Transparent;
        }

        //---------------------------------------------------------------------------
        private String menuName = "아메리카노";
        public String XMenuName
        {
            get { return menuName; }
            set { menuName = value; Invalidate(); }
        }

        private String menuNameEng = "Americano";
        public String XMenuNameEng
        {
            get { return menuNameEng; }
            set { menuNameEng = value; Invalidate(); }
        }

        private String menuPrice = "2.5";
        public String XMenuPrice
        {
            get { return menuPrice; }
            set { menuPrice = value; Invalidate(); }
        }

        private String menuDCPrice = "1.0";
        public String XMenuDCPrice
        {
            get { return menuDCPrice; }
            set { menuDCPrice = value; Invalidate(); }
        }

        public Color borderColor = Color.White;
        public Color XBorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        private Color onHoverBackColor = Color.DarkOrchid;
        public Color XOnHoverBackColor
        {
            get { return onHoverBackColor; }

            set { onHoverBackColor = value; Invalidate(); }
        }
        //---------------------------------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 배경색
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, Width, Height);

            // 텍스트 그리기
            DrawMenuText(e.Graphics, Color.Black);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            //직각 테두리
            Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(0, 161, 223)), 0, 0, Width, Height);

            //
            Pen pen = new Pen(Color.FromArgb(0, 126, 253), 2);
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            Rectangle rect = this.ClientRectangle;
            rect.X += 0;
            rect.Y += 0;
            rect.Width -= 1;
            rect.Height -= 1;
            //g.DrawRectangle(pen, rect);

            // 텍스트 그리기
            DrawMenuText(g, Color.White);
        }

        private void DrawMenuText(Graphics g, Color color)
        {
            TextFormatFlags flags = TextFormatFlags.VerticalCenter;
            {
                //한글 메뉴명
                TextRenderer.DrawText(g, XMenuName, Font, new Point(10, (Height / 2)), color, flags);

                //영문 메뉴명
                TextRenderer.DrawText(g, XMenuNameEng, Font, new Point(200, (Height / 2)), color, flags);

                //가격
                TextRenderer.DrawText(g, XMenuPrice, Font, new Point(400, (Height / 2)), color, flags);

                //할인 가격
                TextRenderer.DrawText(g, XMenuDCPrice, Font, new Point(450, (Height / 2)), Color.DarkRed, flags);
            }
        }
    }
}

