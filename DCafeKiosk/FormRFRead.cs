﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// for HID
using SharpLib.Win32;

namespace DCafeKiosk
{
    public partial class FormRFRead : Form, IPageEventHandler
    {
        #region 'EVENT'
        //++++++++++++++++++++++++++++++++++++++++++++++++
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
        //++++++++++++++++++++++++++++++++++++++++++++++++
        #endregion



        /// <summary>
        /// 읽은 RFID 값 저장
        /// </summary>
        private StringBuilder strRfid = null; // RFID 저장
               
        public FormRFRead()
        {            
            InitializeComponent();

            strRfid = new StringBuilder();

            // RFID 읽기 시작
            StartEventCapture();
        }

        /// <summary>
        /// RestAPI 호출
        /// </summary>
        private void RestApi_CheckRFID()
        {
            for(int i=0; i<=200; i++)
            {
                System.Threading.Thread.Sleep(10); // simulator
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

        /// <summary>
        /// RFID 리더 켜기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOn_Click(object sender, EventArgs e)
        {
            strRfid.Clear();
            StartEventCapture();
        }

        /// <summary>
        /// RFID 리더 끄기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOff_Click(object sender, EventArgs e)
        {
            strRfid.Clear();
            EndEventCapture();
        }

        private void btnTestRF_Click_1(object sender, EventArgs e)
        {
            CompleatedRFRead("abcdefg");
        }

        #region 'HID MONITORING'
        /// <summary>
        /// RF ID 정보 추출 완료되면 호출됨
        /// </summary>
        /// <param name="str"></param>
        private void CompleatedRFRead(string str)
        {
            EndEventCapture();

            // 데이터 로딩 다이얼로그
            using (FormLoadingDialog form = new FormLoadingDialog(RestApi_CheckRFID, StartEventCapture))
            {
                form.TopLevel = true;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }

            // API 확인 후 완료 이벤트 발생
            OnPageSuccess();
        }

        /// <summary>
        /// RAWINPUT 이벤트 수신 시작
        /// </summary>
        private void StartEventCapture()
        {            
            RAWINPUTDEVICE[] rid = new RAWINPUTDEVICE[1];

            // https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrawinputdevice
            // 이 옵션을 설정하면 발신자가 포 그라운드에 있지 않아도 발신자가 입력을받을 수 있습니다. 
            // 참고 hwndTarget을 지정해야 합니다.

            //-------------------------------------------------------
            // RIM_INPUT = FOREGROUND에서만 WM_INPUT 이벤트 수신
            // RIDEV_INPUTSINK = BACKGROUND에서도 WM_INPUT 이벤트 수신
            //-------------------------------------------------------
            int flags = (int)RawInputDeviceFlags.RIDEV_INPUTSINK;
            {
                rid[0].usUsagePage = 0x01;
                rid[0].usUsage = 0x06;
                rid[0].dwFlags = (RawInputDeviceFlags)flags;
                rid[0].hwndTarget = this.Handle;
            }

            uint size = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(RAWINPUTDEVICE));
            if (Function.RegisterRawInputDevices(rid, 1, size) == false)
            {
                Console.WriteLine("ResigterRawInputDevices Error: {0}", Marshal.GetLastWin32Error());
            }
            else
            {
                Console.WriteLine("Registration of device was successful");
            }
        }

        /// <summary>
        /// RAWINPUT 이벤트 수신 중지
        /// </summary>
        private void EndEventCapture()
        {
            RAWINPUTDEVICE[] rid = new RAWINPUTDEVICE[1];

            int flags = (int)RawInputDeviceFlags.RIDEV_REMOVE;
            {
                rid[0].usUsagePage = 0x01;
                rid[0].usUsage = 0x06;
                rid[0].dwFlags = (RawInputDeviceFlags)flags;    // here!
                rid[0].hwndTarget = IntPtr.Zero;                // here!
            }

            //De-register
            uint size = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(RAWINPUTDEVICE));
            if (Function.RegisterRawInputDevices(rid, 1, size) == false)
            {
                Console.WriteLine("De-ResigterRawInputDevices Error: {0}", Marshal.GetLastWin32Error());
            }
            else
            {
                Console.WriteLine("De-Registration of device was successful");
            }
        }

        /// <summary>
        /// HID RAWINPUT 이벤트 핸들러 (WM_INPUT)
        /// </summary>
        /// <param name="message"></param>
        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                //------------------------------------------------------------
                // HID RAW INPUT READ

                case Const.WM_INPUT:
                    {
                        IntPtr rawInputBuffer = IntPtr.Zero;
                        RAWINPUT iRawInput = new RAWINPUT();
                        if (!GetRawInputData(message.LParam, ref iRawInput, ref rawInputBuffer))
                        {
                            Console.WriteLine("GetRawInputData failed!");
                            break;
                        }
                        else
                        {
                            //The key is down.
                            if (iRawInput.header.dwType == RawInputDeviceType.RIM_TYPEKEYBOARD
                                && iRawInput.keyboard.Flags == RawInputKeyFlags.RI_KEY_MAKE)
                            {
                                // VKey 정보 처리 하기
                                ProcessRawInput(iRawInput.keyboard.VKey);

                                Console.WriteLine("RAWINPUT: Header dwSize: 0x{0:X}\r\n",
                                    iRawInput.header.dwSize
                                    );

                                Console.WriteLine("RAWINPUT: VKey: 0x{0:X}\r\n",
                                    iRawInput.keyboard.VKey
                                    );
                            }
                        }
                    }

                    //------------------------------------------------------------

                    //Log that message
                    Console.WriteLine("WM_INPUT: " + message.ToString() + "\r\n");

                    //Returning zero means we processed that message.
                    message.Result = new IntPtr(0);

                    break;
            }
            //Is that needed? Check the docs.
            base.WndProc(ref message);
        }

        /// <summary>
        /// VKEY를 문자열로 변환
        /// </summary>
        /// <param name="virtualKeyCode"></param>
        /// <param name="scanCode"></param>
        /// <param name="keyboardState"></param>
        /// <param name="receivingBuffer"></param>
        /// <param name="bufferSize"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int ToUnicode(
            uint virtualKeyCode,
            uint scanCode,
            byte[] keyboardState,
            StringBuilder receivingBuffer,
            int bufferSize,
            uint flags
        );

        /// <summary>
        /// WM_INPUT으로 들어오는 RFID의 VKey Code를 문자열 변환 처리
        /// VK_ENTER가 나올때 까지 문자열을 만든다.
        /// </summary>
        /// <param name="VKey"></param>
        public void ProcessRawInput(ushort VKey)
        {
            if (VKey == 0x0D) //VK_ENTER
            {
                // read compleat ...
                this.CompleatedRFRead(strRfid.ToString());

                // buffer clear
                strRfid.Clear();
            }
            else
            {
                var buf = new StringBuilder(256);
                var keyboardState = new byte[256];
                ToUnicode((uint)VKey, 0, keyboardState, buf, 256, 0);
                strRfid.Append(buf.ToString());
            }
        }

        /// <summary>
        /// RAWINPUT으로 부터 데이터를 읽는다.
        /// </summary>
        /// <param name="aRawInputHandle"></param>
        /// <param name="aRawInput"></param>
        /// <param name="rawInputBuffer">Caller must free up memory on the pointer using Marshal.FreeHGlobal</param>
        /// <returns></returns>
        public static bool GetRawInputData(IntPtr aRawInputHandle, ref RAWINPUT aRawInput, ref IntPtr rawInputBuffer)
        {
            bool success = true;
            rawInputBuffer = IntPtr.Zero;

            try
            {
                uint dwSize = 0;
                uint sizeOfHeader = (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER));

                //Get the size of our raw input data.
                Function.GetRawInputData(aRawInputHandle, Const.RID_INPUT, IntPtr.Zero, ref dwSize, sizeOfHeader);

                //Allocate a large enough buffer
                rawInputBuffer = Marshal.AllocHGlobal((int)dwSize);

                //Now read our RAWINPUT data
                if (Function.GetRawInputData(aRawInputHandle, Const.RID_INPUT, rawInputBuffer, ref dwSize, (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER))) != dwSize)
                {
                    return false;
                }

                //Cast our buffer
                aRawInput = (RAWINPUT)Marshal.PtrToStructure(rawInputBuffer, typeof(RAWINPUT));
            }
            catch
            {
                Console.WriteLine("GetRawInputData failed!");
                success = false;
            }

            return success;
        }
        #endregion 'HID MONITORING'
    }
}
