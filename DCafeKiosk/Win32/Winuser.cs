using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpLib.Win32
{
    public delegate int HOOKPROC(int code, IntPtr wParam, IntPtr lParam);

    static public partial class Function
    {
        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int GetWindowRect(IntPtr hWnd, ref RECT rect);

        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int w, int h, int repaint);

        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = false)]
        public static extern IntPtr GetActiveWindow();

        [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int GetClassName(IntPtr hwnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType code, HOOKPROC func, IntPtr hInstance, int threadID);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = false)]
        public static extern int CallNextHookEx(IntPtr hhook, int code, IntPtr wParam, IntPtr lParam);
    }

    static public partial class Const
    {
        public const int HCBT_MOVESIZE = 0;
        public const int HCBT_MINMAX = 1;
        public const int HCBT_QS = 2;
        public const int HCBT_CREATEWND = 3;
        public const int HCBT_DESTROYWND = 4;
        public const int HCBT_ACTIVATE = 5;
        public const int HCBT_CLICKSKIPPED = 6;
        public const int HCBT_KEYSKIPPED = 7;
        public const int HCBT_SYSCOMMAND = 8;
        public const int HCBT_SETFOCUS = 9;
    }

    /// Hook Types.
    public enum HookType : int
    {
        WH_MSGFILTER = -1,
        /// <value>0</value>
        WH_JOURNALRECORD = 0,
        /// <value>1</value>
        WH_JOURNALPLAYBACK = 1,
        /// <value>2</value>
        WH_KEYBOARD = 2,
        /// <value>3</value>
        WH_GETMESSAGE = 3,
        /// <value>4</value>
        WH_CALLWNDPROC = 4,
        /// <value>5</value>
        WH_CBT = 5,
        /// <value>6</value>
        WH_SYSMSGFILTER = 6,
        /// <value>7</value>
        WH_MOUSE = 7,
        /// <value>8</value>
        WH_HARDWARE = 8,
        /// <value>9</value>
        WH_DEBUG = 9,
        /// <value>10</value>
        WH_SHELL = 10,
        /// <value>11</value>
        WH_FOREGROUNDIDLE = 11,
        /// <value>12</value>
        WH_CALLWNDPROCRET = 12,
        /// <value>13</value>
        WH_KEYBOARD_LL = 13,
        /// <value>14</value>
        WH_MOUSE_LL = 14
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CWPRETSTRUCT
    {
        public IntPtr lResult;
        public IntPtr lParam;
        public IntPtr wParam;
        public uint message;
        public IntPtr hWnd;
    }

}
