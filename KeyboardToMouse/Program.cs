using System.Runtime.InteropServices;
using KeyboardToMouse.Gui;

namespace KeyboardToMouse
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new KeyToMouse());
        }
    }
    //class Program
    //{
    //    private const uint WM_LBUTTONDOWN = 0x201;
    //    private const uint WM_LBUTTONUP = 0x202;
    //    private const uint MK_LBUTTON = 0x0001;

    //    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr parameter);

    //    [DllImport("user32.dll", SetLastError = true)]
    //    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    //    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    //    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

    //    [DllImport("user32.dll", SetLastError = true)]
    //    public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

    //    [DllImport("user32.dll", SetLastError = true)]
    //    public static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

    //    static IntPtr childWindow;

    //    static void Main(string[] args)
    //    {
    //        IntPtr hwndMain = WinApi.FindWindow("MSPaintApp", null);
    //        IntPtr hwndView = WinApi.FindWindowEx(hwndMain, IntPtr.Zero, "MSPaintView", null);
    //        // Getting the child windows of MSPaintView because it seems that the class name of the child isn't constant
    //        WinApi.EnumChildWindows(hwndView, new WinApi.EnumWindowsProc(MouseManager.EnumWindow), IntPtr.Zero);
    //        // Simulate press of left mouse button on coordinates 10, 10
    //        var test1 = WinApi.SendMessage(MouseManager.childWindow, (uint)WindowsMessages.WM_LBUTTONDOWN, new IntPtr((int)VKeys.KEY_CONTROL), MouseManager.GetLParam(10, 10));
    //        // Simulate release of left mouse button on coordinates 100, 100
    //        var test2 = WinApi.SendMessage(MouseManager.childWindow, (uint)WindowsMessages.WM_LBUTTONUP, new IntPtr((int)VKeys.KEY_CONTROL), MouseManager.GetLParam(100, 100));

    //        //IntPtr hwndMain = FindWindow("MSPaintApp", null);
    //        //IntPtr hwndView = FindWindowEx(hwndMain, IntPtr.Zero, "MSPaintView", null);
    //        //// Getting the child windows of MSPaintView because it seems that the class name of the child isn't constant
    //        //EnumChildWindows(hwndView, new EnumWindowsProc(EnumWindow), IntPtr.Zero);
    //        //// Simulate press of left mouse button on coordinates 10, 10
    //        //SendMessage(childWindow, WM_LBUTTONDOWN, new IntPtr(MK_LBUTTON), CreateLParam(10, 10));
    //        //// Simulate release of left mouse button on coordinates 100, 100
    //        //SendMessage(childWindow, WM_LBUTTONUP, new IntPtr(MK_LBUTTON), CreateLParam(100, 100));
    //    }

    //    static bool EnumWindow(IntPtr handle, IntPtr pointer)
    //    {
    //        // Get the first child because it seems that MSPaintView has only this child
    //        childWindow = handle;
    //        // Stop enumerating the windows
    //        return false;
    //    }

    //    private static IntPtr CreateLParam(int LoWord, int HiWord)
    //    {
    //        return (IntPtr)((HiWord << 16) | (LoWord & 0xffff));
    //    }
    //}
}

