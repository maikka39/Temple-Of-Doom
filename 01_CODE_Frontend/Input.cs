using System;
using CODE_GameLib;

namespace CODE_Frontend
{
    public static class Input
    {
        public static TickData HandleKey(ConsoleKey key)
        {
            var tickData = new TickData();

            // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
            switch (key)
            {
                case ConsoleKey.K:
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    tickData.MovePlayer = Direction.Top;
                    break;

                case ConsoleKey.J:
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    tickData.MovePlayer = Direction.Bottom;
                    break;

                case ConsoleKey.H:
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    tickData.MovePlayer = Direction.Left;
                    break;

                case ConsoleKey.L:
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    tickData.MovePlayer = Direction.Right;
                    break;

                case ConsoleKey.Escape:
                    tickData.Quit = true;
                    break;
            }

            return tickData;
        }
    }
}
