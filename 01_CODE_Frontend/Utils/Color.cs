using System;

namespace CODE_Frontend.Utils
{
    public static class Color
    {
        public static ConsoleColor ColorToConsoleColor(System.Drawing.Color color)
        {
            return (ConsoleColor) Enum.Parse(typeof(ConsoleColor), color.Name, true);
        }
    }
}
