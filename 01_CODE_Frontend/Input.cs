using System;
using CODE_GameLib;
using CODE_GameLib.Enums;

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
                case ConsoleKey.UpArrow:
                    tickData.MovePlayer = Direction.North;
                    break;

                case ConsoleKey.DownArrow:
                    tickData.MovePlayer = Direction.South;
                    break;

                case ConsoleKey.LeftArrow:
                    tickData.MovePlayer = Direction.West;
                    break;

                case ConsoleKey.RightArrow:
                    tickData.MovePlayer = Direction.East;
                    break;

                case ConsoleKey.Escape:
                    tickData.Quit = true;
                    break;
            }

            return tickData;
        }
    }
}
