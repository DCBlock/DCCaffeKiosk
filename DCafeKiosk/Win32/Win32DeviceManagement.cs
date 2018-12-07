using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace SharpLib.Win32
{
    /// <summary>
    /// 
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct OVERLAPPED
    {

        /// ULONG_PTR->unsigned int
        [FieldOffset(0)]
        public uint Internal;

        /// ULONG_PTR->unsigned int
        [FieldOffset(4)]
        public uint InternalHigh;

        /// DWORD->unsigned int
        [FieldOffset(8)]        
        public uint Offset;

        /// DWORD->unsigned int
        [FieldOffset(12)]       
        public uint OffsetHigh;

        /// PVOID->void*
        /// Union
        [FieldOffset(8)]
        public System.IntPtr Pointer;

        /// HANDLE->void*
        [FieldOffset(16)]
        public System.IntPtr hEvent;
    }

    /// <summary>
    /// 
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct PREVENT_MEDIA_REMOVAL
    {

        /// BOOLEAN->BYTE->unsigned char
        public byte PreventMediaRemoval;
    }


    public partial class Function
    {

        /// Return Type: BOOL->int
        ///hDevice: HANDLE->void*
        ///dwIoControlCode: DWORD->unsigned int
        ///lpInBuffer: LPVOID->void*
        ///nInBufferSize: DWORD->unsigned int
        ///lpOutBuffer: LPVOID->void*
        ///nOutBufferSize: DWORD->unsigned int
        ///lpBytesReturned: LPDWORD->DWORD*
        ///lpOverlapped: LPOVERLAPPED->_OVERLAPPED*
        [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "DeviceIoControl", SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool DeviceIoControl(
            [System.Runtime.InteropServices.InAttribute()] SafeFileHandle hDevice,
            uint dwIoControlCode,
            [System.Runtime.InteropServices.InAttribute()] System.IntPtr lpInBuffer,
            uint nInBufferSize,
            System.IntPtr lpOutBuffer,
            uint nOutBufferSize,
            System.IntPtr lpBytesReturned,
            ref OVERLAPPED lpOverlapped);

    }
}
