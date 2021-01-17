using System;

namespace CODE_Frontend.Utils
{
    /// <summary>
    /// Contains util methods for colors
    /// </summary>
    public static class Color
    {
        /// <summary>
        /// Converts a System.Drawing.Color to a ConsoleColor
        /// </summary>
        /// <param name="color">The color to convert</param>
        /// <returns>The converted color</returns>
        public static ConsoleColor ColorToConsoleColor(System.Drawing.Color color)
        {
            return (ConsoleColor) Enum.Parse(typeof(ConsoleColor), color.Name, true);
        }
    }
}
