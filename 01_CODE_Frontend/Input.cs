using System;
using System.Collections.Generic;
using CODE_GameLib;
using CODE_GameLib.Enums;

namespace CODE_Frontend
{
    /// <summary>
    /// Handles the key input of the user
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Handles the key input of the user
        /// </summary>
        /// <param name="key">The key that has been pressed</param>
        /// <returns>The tickdata generated from the pressed key</returns>
        public static TickData HandleKey(ConsoleKey key)
        {
            var tickData = new TickData();
            var toggleCheats = new List<Cheat>();

            // Handle the key
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

                case ConsoleKey.Spacebar:
                    tickData.Shoot = true;
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
