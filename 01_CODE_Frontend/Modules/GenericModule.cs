using System;

namespace CODE_Frontend.Modules
{
    public static class GenericModule
    {
        public static string HorizontalLine(int width)
        {
            return new string('-', width) + Environment.NewLine;
        }
        
        public static string ConsoleClearLineTillEnd()
        {
            return new string(' ', Console.WindowWidth - Console.CursorLeft);
        }
    }
}
