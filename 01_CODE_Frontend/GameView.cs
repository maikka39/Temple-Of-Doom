using System;
using System.Text;
using CODE_Frontend.Modules;
using CODE_Frontend.Utils;
using CODE_GameLib.Interfaces;

namespace CODE_Frontend
{
    public class GameView
    {
        private readonly HeaderModule _headerModule;

        public GameView()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            _headerModule = new HeaderModule();
        }

        /// <summary>
        /// Updates the screen with the nem game info
        /// </summary>
        /// <param name="game">The newest state of the game</param>
        public void Update(IGame game)
        {
            Console.SetCursorPosition(0, 1);

            foreach (var consoleText in _headerModule.Render(game))
                Print(consoleText);

            Console.WriteLine(Screen.ConsoleClearLineTillEnd());

            var grid = new RoomView(game.Player.Location.Room, game.Player).GetGrid();

            var spacing = new ConsoleText(" ");

            for (var row = 0; row < grid.GetLength(1); row++)
            {
                for (var col = 0; col < grid.GetLength(0); col++)
                {
                    Print(grid[col, row]);
                    Print(spacing);
                }

                Console.WriteLine(Screen.ConsoleClearLineTillEnd());
            }

            var originalCursorTop = Console.CursorTop + 1;

            for (var row = originalCursorTop; row < Console.WindowHeight; row++)
                Console.WriteLine(Screen.ConsoleClearLineTillEnd());

            Console.SetCursorPosition(0, originalCursorTop);

            if (game.Player.Died)
                Console.WriteLine("Oh no Indiana, you have lost!");
            else if (game.Player.Won)
                Console.WriteLine("Congrats you have escaped the Temple of Doom!");

            if (game.Quit)
                Console.WriteLine("Stopping...");
        }

        /// <summary>
        /// Print a console text to the screen
        /// </summary>
        /// <param name="consoleText">The console text to print</param>
        private static void Print(ConsoleText consoleText)
        {
            Console.ForegroundColor = consoleText.ForegroundColor;
            Console.BackgroundColor = consoleText.BackgroundColor;
            Console.Write(consoleText.Text);
        }
    }
}
