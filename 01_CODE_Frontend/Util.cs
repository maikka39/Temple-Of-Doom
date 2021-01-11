using System;
using System.Drawing;

namespace CODE_Frontend
{
    public static class Util
    {
        public static ConsoleColor ColorToConsoleColor(Color color)
        {
            return (ConsoleColor) Enum.Parse(typeof(ConsoleColor), color.Name, true);
        }
    }
}
