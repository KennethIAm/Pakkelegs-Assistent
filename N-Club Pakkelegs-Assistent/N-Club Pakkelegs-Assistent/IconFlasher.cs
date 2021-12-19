using System;
using System.Runtime.InteropServices;

namespace N_Club_Pakkelegs_Assistent
{
    static class IconFlasher
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 flashDuration;
            public Int32 flashInterval;
        }

        public const UInt32 FLASHW_ALL = 3;

        public static void FlashWindow(IntPtr hWnd)
        {
            FLASHWINFO fInfo = new FLASHWINFO();

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = FLASHW_ALL;
            fInfo.flashDuration = 3;
            fInfo.flashInterval = 0;

            FlashWindowEx(ref fInfo);
        }
    }
}
