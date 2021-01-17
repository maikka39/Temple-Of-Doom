using System;

namespace CODE_Frontend.Modules
{
    /// <summary>
    /// Module that contains some basic functionalities for the view
    /// </summary>
    public static class GenericModule
    {
        /// <summary>
        /// Creates a horizontal line
        /// </summary>
        /// <param name="width">The lenght of the line</param>
        /// <returns>A string of '-' chars</returns>
        public static string HorizontalLine(int width)
        {
            return new string('-', width) + Environment.NewLine;
        }
        
        /// <summary>
        /// Fills the rest of the screen with spaces, this is to clear the screen without causing flickering issues
        /// </summary>
        /// <returns>A string of spaces with the length of the amount of screen width left</returns>
        public static string ConsoleClearLineTillEnd()
        {
            return new string(' ', Console.WindowWidth - Console.CursorLeft);
        }
    }
}
