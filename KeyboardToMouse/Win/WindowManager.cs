using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardToMouse.Win
{
    public class WindowManager
    {

        #region WinApi

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public struct WindowInfo
        {
            public uint cbSize;
            public Rectangle rcWindow;
            public Rectangle rcClient;
            public uint dwStyle;
            public uint dwExStyle;
            public uint dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public ushort atomWindowType;
            public ushort wCreatorVersion;

            public WindowInfo(bool? filler) : this()   // Allows automatic initialization of "cbSize" with "new WINDOWINFO(null/true/false)".
            {
                cbSize = (uint)Marshal.SizeOf(typeof(WindowInfo));
            }

        }
        #endregion WinApi

        public static void SetTopMost(nint hWnd)
        {
            WinApi.SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        public static Rectangle GetActualWindowRectangle(nint hWnd)
        {
            var innerWindow = GetInnerWindowRectangle(hWnd);
            var windowInfo = GetWindowInformation(hWnd);
            //Total Window
            var rcWindow = windowInfo.rcWindow;
            //Drawing Area Only
            var rcClient = windowInfo.rcClient;
            var heightDiff = rcWindow.Height - rcClient.Height;
            return new Rectangle(rcWindow.X, rcWindow.Y, innerWindow.Width, innerWindow.Height - heightDiff);
        }
        public static Rectangle GetInnerWindowRectangle(nint hWnd)
        {
            WinApi.GetClientRect(hWnd, out var rect);
            return rect;
        }
        /// <summary>
        /// Gets the information for a running program.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static WindowInfo GetWindowInformation(nint hWnd)
        {
            WindowInfo info = new WindowInfo();
            info.cbSize = (uint)Marshal.SizeOf(info);
            WinApi.GetWindowInfo(hWnd, ref info);
            return info;
        }

        /// <summary>
        /// Gets the Rectangle size/location for a running program.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static Rectangle GetWindowRectangle(nint hWnd)
        {
            WinApi.GetWindowRect(hWnd, out var rect);
            return rect;
        }
        public static List<nint> GetAllChildrenWindowHandles(nint hParent, int maxCount)
        {
            List<nint> result = new List<nint>();
            int ct = 0;
            nint prevChild = nint.Zero;
            nint currChild = nint.Zero;
            while (true && ct < maxCount)
            {
                currChild = WinApi.FindWindowEx(hParent, prevChild, null, null);
                if (currChild == nint.Zero) break;
                result.Add(currChild);
                prevChild = currChild;
                ++ct;
            }
            return result;
        }
        public static List<nint> GetAllIntPtr(nint handle)
        {
            List<nint> listOfIntPtrs = new List<nint>();
            nint currentIntPtr = handle;
            nint lastIntPtr = nint.Zero;
            listOfIntPtrs.Add(handle);
            while (currentIntPtr != nint.Zero)
            {
                currentIntPtr = WinApi.FindWindowEx(currentIntPtr, lastIntPtr, null, null);
                listOfIntPtrs.Add(currentIntPtr);
                lastIntPtr = currentIntPtr;
            }

            return listOfIntPtrs;
        }

        public static List<int> FindTitlelessWindows()
        {
            List<int> titleless = new List<int>();

            Process[] procs = Process.GetProcesses();
            nint hWnd;

            foreach (Process proc in procs)
            {
                hWnd = proc.MainWindowHandle;
                if (hWnd != nint.Zero)
                {
                    TraverseHierarchy(hWnd.ToInt32(), 0, titleless);

                }
            }

            foreach (int i in titleless)
            {
                Debug.WriteLine(i);
            }

            return titleless;
        }
        public static List<int> FindTitlelessWindows(nint process)
        {
            List<int> titleless = new List<int>();
            TraverseHierarchy(process.ToInt32(), 0, titleless);

            foreach (int i in titleless)
            {
                Debug.WriteLine(i);
            }

            return titleless;
        }

        public static List<int> FindTitlelessWindows(Process process)
        {
            List<int> titleless = new List<int>();
            TraverseHierarchy(process.MainWindowHandle.ToInt32(), 0, titleless);

            foreach (int i in titleless)
            {
                Debug.WriteLine(i);
            }

            return titleless;
        }

        public static void TraverseHierarchy(int parent, int child, List<int> titleless)
        {
            string text = "";
            WinApi.GetWindowText(parent, text, WinApi.GetWindowTextLength(parent));
            if (string.IsNullOrEmpty(text))
            {
                titleless.Add(parent);
            }

            TraverseChildern(parent, titleless);
            TraversePeers(parent, child, titleless);

        }

        public static void TraverseChildern(int handle, List<int> titleless)
        {
            // First traverse child windows
            const uint GW_CHILD = 0x05;
            int child = WinApi.GetWindow(handle, GW_CHILD);
            if (0 != child)
            {
                TraverseHierarchy(child, 0, titleless);
            }
        }

        public static void TraversePeers(int parent, int start, List<int> titleless)
        {
            // Next traverse peers
            int peer = WinApi.FindWindowEx(parent, start, "");
            if (0 != peer)
            {
                TraverseHierarchy(parent, peer, titleless);
            }
        }
    }
}
