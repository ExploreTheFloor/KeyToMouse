using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using KeyboardToMouse.Win;

namespace KeyboardToMouse.KBM
{
    public class MouseManager
    {
        public enum MouseFlags : uint
        {
            MOVE_NOCOALESCE = 0x2000, //The WM_MOUSEMOVE messages will not be coalesced. The default behavior is to coalesce WM_MOUSEMOVE messages.
            VIRTUALDESK = 0x4000, //Maps coordinates to the entire desktop. Must be used with MOUSEEVENTF_ABSOLUTE.
            ABSOLUTE = 0x8000,   // If set, dx and dy contain normalized absolute coordinates between 0 and 65535. The event procedure maps these coordinates onto the display surface. Coordinate (0,0) maps onto the upper-left corner of the display surface, (65535,65535) maps onto the lower-right corner.
            LEFTDOWN = 0x0002,   // The left button is down.
            LEFTUP = 0x0004,     // The left button is up.
            MIDDLEDOWN = 0x0020, // The middle button is down.
            MIDDLEUP = 0x0040,   // The middle button is up.
            MOVE = 0x0001,       // Movement occurred.
            RIGHTDOWN = 0x0008,  // The right button is down.
            RIGHTUP = 0x0010,    // The right button is up.
            WHEEL = 0x0800,      // The wheel has been moved, if the mouse has a wheel.The amount of movement is specified in dwData
            XDOWN = 0x0080,      // An X button was pressed.
            XUP = 0x0100,        // An X button was released.
            HWHEEL = 0x01000     // The wheel button is tilted.
        }
        public enum MouseButton
        {
            Left, Right, Middle, X1
        }

        public static nint GetLParam(int x, int y)
        {
            return (nint)(y << 16) | x & 0xFFFF;
        }
        public static nint childWindow;
        public static bool EnumWindow(nint handle, nint pointer)
        {
            // Get the first child because it seems that MSPaintView has only this child
            childWindow = handle;
            // Stop enumerating the windows
            return false;
        }

        public static Task MoveToPosition(nint hWnd, Point point, MouseButton mButton, int delay = 10, Keys key = Keys.None)
        {
            WinApi.SendMessage(hWnd, (uint)WindowsMessages.WM_MOUSEMOVE, new nint(0), GetLParam(point.X, point.Y));
            return Task.CompletedTask;
        }
        public static Task ClickAtPosition(nint hWnd, Point point, MouseButton mButton, int delay = 10,
            Keys key = Keys.None)
        {
            switch (mButton)
            {
                default:
                case MouseButton.Left:
                    {

                        WinApi.SendMessage(hWnd, (uint)WindowsMessages.WM_LBUTTONDOWN, new nint(0x0001),
                            GetLParam(point.X, point.Y));
                        Thread.Sleep(delay);
                        WinApi.SendMessage(hWnd, (uint)WindowsMessages.WM_LBUTTONUP, new nint(0x0001),
                            GetLParam(point.X, point.Y));
                        break;
                    }
                case MouseButton.Middle:
                    {
                        WinApi.SendMessage(hWnd, (uint)WindowsMessages.WM_MBUTTONDOWN, new nint(0x0001),
                            GetLParam(point.X, point.Y));
                        Thread.Sleep(delay);
                        WinApi.SendMessage(hWnd, (uint)WindowsMessages.WM_MBUTTONUP, new nint(0x0001),
                            GetLParam(point.X, point.Y));
                        break;
                    }
                case MouseButton.Right:
                    {
                        WinApi.SendMessage(hWnd, (uint)WindowsMessages.WM_RBUTTONDOWN, new nint(0x0001),
                            GetLParam(point.X, point.Y));
                        Thread.Sleep(delay);
                        WinApi.SendMessage(hWnd, (uint)WindowsMessages.WM_RBUTTONUP, new nint(0x0001),
                            GetLParam(point.X, point.Y));
                        break;
                    }
            }

            return Task.CompletedTask;
        }

        public static Task ClickAtPosition(Point point, MouseButton mButton, int delay = 10)
        {
            switch (mButton)
            {
                default:
                case MouseButton.Left:
                    {
                        WinApi.mouse_event((uint)MouseFlags.LEFTDOWN | (uint)MouseFlags.ABSOLUTE | (uint)MouseFlags.MOVE, point.X, point.Y, 0, nint.Zero);
                        Thread.Sleep(delay);
                        WinApi.mouse_event((uint)MouseFlags.LEFTUP | (uint)MouseFlags.ABSOLUTE | (uint)MouseFlags.MOVE, point.X, point.Y, 0, nint.Zero);
                        break;
                    }
                case MouseButton.Middle:
                    {
                        WinApi.mouse_event((uint)MouseFlags.MIDDLEDOWN | (uint)MouseFlags.ABSOLUTE | (uint)MouseFlags.MOVE, point.X, point.Y, 0, nint.Zero);
                        Thread.Sleep(delay);
                        WinApi.mouse_event((uint)MouseFlags.MIDDLEUP | (uint)MouseFlags.ABSOLUTE | (uint)MouseFlags.MOVE, point.X, point.Y, 0, nint.Zero);
                        break;
                    }
                case MouseButton.Right:
                    {
                        WinApi.mouse_event((uint)MouseFlags.RIGHTDOWN | (uint)MouseFlags.ABSOLUTE | (uint)MouseFlags.MOVE, point.X, point.Y, 0, nint.Zero);
                        Thread.Sleep(delay);
                        WinApi.mouse_event((uint)MouseFlags.RIGHTUP | (uint)MouseFlags.ABSOLUTE | (uint)MouseFlags.MOVE, point.X, point.Y, 0, nint.Zero);
                        break;
                    }
            }

            return Task.CompletedTask;
        }
        public static async Task LinearSmoothClick(nint hWnd, MouseButton mButton, Point startPoint, Point endPoint, int steps, int moveDelay)
        {
            PointF iterPoint = startPoint;

            // Find the slope of the line segment defined by start and endPoint
            PointF slope = new PointF(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);

            // Divide by the number of steps
            slope.X /= steps;
            slope.Y /= steps;

            // Move the mouse to each iterative point.
            for (int i = 0; i < steps; i++)
            {
                iterPoint = new PointF(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                ClickAtPosition(hWnd, Point.Round(iterPoint), mButton);
                Thread.Sleep(moveDelay);
            }

            // Move the mouse to the final destination.
            ClickAtPosition(hWnd, endPoint, mButton);
            Thread.Sleep(moveDelay);
        }
    }
}
