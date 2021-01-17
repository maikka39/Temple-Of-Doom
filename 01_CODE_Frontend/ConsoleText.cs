using System;

namespace CODE_Frontend
{
    /// <summary>
    ///     A class in which text is saved together with the colors it should be printed in.
    /// </summary>
    public class ConsoleText
    {
        public ConsoleText(string text, ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Text = text;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Specifies the text to display
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// Specifies the color of the text
        /// </summary>
        public ConsoleColor ForegroundColor { get; set; }
        
        /// <summary>
        /// Specifies the background color
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }
    }
}
