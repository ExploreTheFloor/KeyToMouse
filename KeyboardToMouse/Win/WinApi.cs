using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static KeyboardToMouse.Win.WindowManager;

namespace KeyboardToMouse.Win
{
    public class WinApi
    {
        public delegate bool EnumWindowsProc(nint hWnd, nint parameter);

        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern uint SendInput(uint nInputs, ref Input pInputs, int cbSize);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPosition(out Point point);

        [DllImport("User32.Dll", SetLastError = true)]
        public static extern long SetCursorPosition(int x, int y);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int cButtons, nint dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SendMessage(nint hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern nint SendMessage(nint hWnd, uint Msg, nint wParam, nint lParam);

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern bool PostMessage(nint hWnd, int Msg, uint wParam, uint lParam);

        [DllImport("User32.Dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern bool PostMessage(nint hWnd, uint msg, nint wParam, nint lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(nint hWnd, out Rectangle lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(nint hWnd, out Rectangle rect);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowInfo(nint hwnd, ref WindowInfo pwi);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(nint hWnd);

        [DllImport("user32")]
        internal static extern int GetWindowText(int hWnd, string text, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(int hWnd);

        [DllImport("user32.dll")]
        public static extern int FindWindow(string text, string class_name);

        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int parent, int start, string class_name);

        [DllImport("user32.dll")]
        public static extern nint FindWindowEx(nint hwndParent, nint hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        public static extern int GetWindow(int parent, uint cmd); [DllImport("user32.dll", SetLastError = true)]
        public static extern bool EnumChildWindows(nint hwndParent, EnumWindowsProc lpEnumFunc, nint lParam);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    }
}
