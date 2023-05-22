
using System.Text.RegularExpressions;
using System.Drawing;

namespace KeyboardToMouse
{
    public static class Extensions
    {
        public static string RemoveAllNonAlphaNumeric(this string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9]", "");
        }
        public static Point GetWindowMiddlePoint(this Rectangle rect)
        {
            return new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
        }
        public static Point GetMiddlePoint(this Rectangle rect)
        {
            return new Point(rect.Width / 2, rect.Height / 2);
        }

    }
}
