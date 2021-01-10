using System;
using System.Collections.Generic;
using CODE_GameLib;
using CODE_GameLib.Enums;

namespace CODE_Frontend
{
    public static class Input
    {
        public static TickData HandleKey(ConsoleKey key)
        {
            var tickData = new TickData();
            var toggleCheats = new List<Cheat>();

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
                
                case ConsoleKey.L:
                    toggleCheats.Add(Cheat.Invincible);
                    break;
                
                case ConsoleKey.D:
                    toggleCheats.Add(Cheat.IgnoreDoors);
                    break;

                case ConsoleKey.Escape:
                    tickData.Quit = true;
                    break;
            }

            if (toggleCheats.Count > 0)
                tickData.ToggleCheats = toggleCheats;

            return tickData;
        }
    }
}
