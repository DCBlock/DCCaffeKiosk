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
    public partial class UCMenuButton : UserControl
    {
        private String eventName = "이벤트명";
        public String XEventName
        {
            get { return eventName; }
            set { eventName = value; Invalidate(); }
        }

        private String menuNameKR = "제품명";
        public String XMenuNameKR
        {
            get { return menuNameKR; }
            set { menuNameKR = value; Invalidate(); }
        }

        private String menuNameEN = "Product Name";
        public String XMenuNameEN
        {
            get { return menuNameEN; }
            set { menuNameEN = value; Invalidate(); }
        }

        private String menuSize = "REGULAR";
        public String XMenuSize
        {
            get { return menuSize; }
            set { menuSize = value; Invalidate(); }
        }
        
        public String XMenuType { get; set; } = "BOTH";

        private int menuPrice = 2500;
        public int XMenuPrice
        {
            get { return menuPrice; }
            set { menuPrice = value; Invalidate(); }
        }

        [Browsable(false)]
        public int XDCDigicapPrice { get; set; } = 1000;

        [Browsable(false)]
        public int XDCCovisionPrice { get; set; } = 0;

        [Browsable(false)]
        public int XCategoryCode { get; set; } = 0;

        [Browsable(false)]
        public int XMenuCode { get; set; } = 0;

        //---------------------------------------------------------------------------

        public Color borderColor = Color.Gainsboro;
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

        public UCMenuButton()
        {
            InitializeComponent();

            DoubleBuffered = true;
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //배경색
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, Width, Height);

            //배경 이미지
            if(BackgroundImage != null)
            {
                e.Graphics.DrawImage(BackgroundImage, 0, 0, Width, Height);
            }

            // 상단 이벤트 타이틀바 배경
            if(XEventName != string.Empty) {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 235, 82, 87)), 0, 5, Width, 25);
            }

            // 하단 타이블바 배경
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, 200, 200, 200)), 0, Height - 55, Width, Height);

            // 글자 출력
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            {
                // 이벤트명
                TextRenderer.DrawText(e.Graphics, XEventName, Font, new Point(Width + 3, 18), Color.White, flags);

                // 메뉴명
                TextRenderer.DrawText(e.Graphics, XMenuNameKR, Font, new Point(Width + 3, (Height / 2) - 30), ForeColor, flags);

                // 사이즈
                TextRenderer.DrawText(e.Graphics, XMenuSize, Font, new Point(Width + 3, (Height / 2) - 0), ForeColor, flags);

                // 선택 옵션
                string _strTypes;
                if (XMenuType.ToUpper() == "BOTH")
                    _strTypes = String.Format("HOT/ICED");
                else
                    _strTypes = XMenuType.ToUpper();
                TextRenderer.DrawText(e.Graphics, _strTypes, Font, new Point(Width + 3, (Height / 2) + 30), Color.DeepSkyBlue, flags);

                // 메뉴 가격
                TextRenderer.DrawText(e.Graphics, XMenuPrice.ToString(), Font, new Point(Width + 3, Height - 30), ForeColor, flags);
            }

            //직각 테두리 그리기
            {
                Rectangle rect = this.ClientRectangle;
                rect.X -= 1;
                rect.Y -= 1;
                rect.Width += 1;
                rect.Height += 1;

                Pen pen = new Pen(borderColor, 2);
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(229, 78, 58), 3);
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

            //직각 테두리
            //g.DrawRectangle(pen, this.ClientRectangle);

            //라운드 테두리
            {
                RectangleF rect = this.ClientRectangle;
                rect.X -= 1;
                rect.Y -= 1;
                rect.Width += 1;
                rect.Height += 1;

                GraphicsPath path = MakeRoundedRect(rect, 2, 2, true, true, true, true);
                g.DrawPath(pen, path);
            }
        }

        // Draw a rectangle in the indicated Rectangle
        // rounding the indicated corners.
        private GraphicsPath MakeRoundedRect(
            RectangleF rect, float xradius, float yradius,
            bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            // Make a GraphicsPath to draw the rectangle.
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Upper left corner.
            if (round_ul)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Top side.
            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Right side.
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Bottom side.
            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Left side.
            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();

            return path;
        }
    }
}

