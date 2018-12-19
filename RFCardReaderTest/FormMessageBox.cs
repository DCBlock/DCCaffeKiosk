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
    public enum CustomMessageBoxButtons
    {
        //
        // Summary:
        //     The message box contains an OK button.
        OK = 0,
        //
        // Summary:
        //     The message box contains OK and Cancel buttons.
        OKCancel = 1,
        //
        // Summary:
        //     The message box contains Abort, Retry, and Ignore buttons.
        AbortRetryIgnore = 2,
        //
        // Summary:
        //     The message box contains Yes, No, and Cancel buttons.
        YesNoCancel = 3,
        //
        // Summary:
        //     The message box contains Yes and No buttons.
        YesNo = 4,
        //
        // Summary:
        //     The message box contains Retry and Cancel buttons.
        RetryCancel = 5,
        /// <summary>
        /// 
        /// </summary>
        HotIced = 6,        
        /// <summary>
        /// 
        /// </summary>
        OrderOkCancle = 7
    }

    public partial class FormMessageBox : Form
    {
        //==========================================================================================
        // Shadow + Mouse Move for Borderless Windows Forms Application C#
        // https://jailbreakvideo.ru/shadow-and-mouse-move-for-borderless-windows-forms-application
        //==========================================================================================
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }
        //=======================================================================================


        /// <summary>
        /// 프로퍼티
        /// </summary>
        public Color XColorTitle
        {
            set { this.labelCaption.BackColor = value; Invalidate(); }
        }

        MessageBoxButtons? buttons;
        CustomMessageBoxButtons? custom_buttons;

        public FormMessageBox()
        {
            InitializeComponent();

            this.Paint += FormMessageBox_Paint;
            this.Load += FormMessageBox_Load;

            this.bunifuThinButton_left.Click += BunifuThinButton_left_Click;
            this.bunifuThinButton_right.Click += BunifuThinButton_right_Click;
        }

        private void FormMessageBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = DisplayRectangle;
            {
                rect.X += 0;
                rect.Y += 0;
                rect.Width -= 1;
                rect.Height -= 1;
            }
            
            e.Graphics.DrawRectangle(new Pen(Color.DarkGray, 1), rect);
        }

        //public FormMessageBox(string text, string caption, MessageBoxButtons buttons)
        //{
        //    InitializeComponent();

        //    this.labelCaption.Text = caption;
        //    this.labelText.Text = text;
        //    this.buttons = buttons;

        //    //
        //    this.Load += FormMessageBox_Load;
        //    this.bunifuThinButton_left.Click += BunifuThinButton_left_Click;
        //    this.bunifuThinButton_right.Click += BunifuThinButton_right_Click;
        //}

        //public DialogResult ShowDialog(string text, string caption, MessageBoxButtons buttons)
        //{
        //    this.labelCaption.Text = caption;
        //    this.labelText.Text = text;

        //    this.buttons = buttons;
        //    this.custom_buttons = null;            

        //    return base.ShowDialog();
        //}

        public DialogResult ShowDialog(string text, string caption, CustomMessageBoxButtons buttons)
        {
            this.labelCaption.Text = caption;
            this.labelText.Text = text;

            this.buttons = null;
            this.custom_buttons = buttons;

            return base.ShowDialog();
        }

        private void BunifuThinButton_left_Click(object sender, EventArgs e)
        {
            if(((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText.CompareTo(@"확인") == 0)
            {
                this.DialogResult = DialogResult.OK;
            }

            if (((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText.CompareTo(@"재시도") == 0)
            {
                this.DialogResult = DialogResult.Retry;
            }

            if (((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText.CompareTo(@"네") == 0)
            {
                this.DialogResult = DialogResult.Yes;
            }

            if (((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText.CompareTo(@"HOT") == 0)
            {
                this.DialogResult = DialogResult.OK;   // HOT
            }

            if (((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText.CompareTo(@"주문 완료") == 0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BunifuThinButton_right_Click(object sender, EventArgs e)
        {
            if (((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText.CompareTo(@"취소") == 0)
            {
                this.DialogResult = DialogResult.Cancel;
            }

            if (((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText.CompareTo(@"아니오") == 0)
            {
                this.DialogResult = DialogResult.No;
            }

            if (((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText.CompareTo(@"ICED") == 0)
            {
                this.DialogResult = DialogResult.Cancel;    // ICED
            }

            if (((Bunifu.Framework.UI.BunifuThinButton2)sender).ButtonText.CompareTo(@"주문 수정") == 0)
            {
                this.DialogResult = DialogResult.Cancel;
            }

            this.Close();
        }

        private void FormMessageBox_Load(object sender, EventArgs e)
        {
            if(custom_buttons != null)
            {
                switch (custom_buttons)
                {
                    case CustomMessageBoxButtons.OKCancel: // 확인-취소
                        {
                            this.bunifuThinButton_left.ButtonText = @"확인";
                            this.bunifuThinButton_right.ButtonText = @"취소";

                            break;
                        }
                    case CustomMessageBoxButtons.RetryCancel: // 재시도-취소
                        {
                            this.bunifuThinButton_left.ButtonText = @"재시도";
                            this.bunifuThinButton_right.ButtonText = @"취소";

                            break;
                        }
                    case CustomMessageBoxButtons.OK: // 확인
                        {
                            this.bunifuThinButton_left.ButtonText = @"확인";
                            bunifuThinButton_left.Left = (ClientSize.Width - bunifuThinButton_left.Width) / 2;

                            bunifuThinButton_right.Hide();

                            break;
                        }
                    case CustomMessageBoxButtons.YesNo: // 네-아니오
                        {
                            this.bunifuThinButton_left.ButtonText = @"네";
                            this.bunifuThinButton_right.ButtonText = @"아니오";

                            break;
                        }
                    case CustomMessageBoxButtons.HotIced: // HOT-ICED
                        {
                            this.bunifuThinButton_left.ButtonText = @"HOT";
                            this.bunifuThinButton_right.ButtonText = @"ICED";

                            break;
                        }
                    case CustomMessageBoxButtons.OrderOkCancle:
                        {
                            this.bunifuThinButton_left.ButtonText = @"주문 완료";
                            this.bunifuThinButton_right.ButtonText = @"주문 수정";

                            break;
                        }
                    default:
                        {
                            this.bunifuThinButton_left.Hide();
                            this.bunifuThinButton_right.Hide();
                            break;
                        }
                } // switch 
            }
        }
    } // class
} // namespace
