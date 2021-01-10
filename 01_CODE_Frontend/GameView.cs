using CODE_Frontend.Modules;
using CODE_GameLib.Interfaces;
using System;
using System.Text;
using CODE_Frontend.ViewModel;

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

        public void Update(IGame game)
        {
            Console.SetCursorPosition(0, 1);

            foreach (var consoleText in _headerModule.Render(game))
            {
                Print(consoleText);
            }
            
            Console.WriteLine(ConsoleClearLineTillEnd());

            var grid = new RoomViewModel(game.Player.Location.Room, game.Player).GetGrid();
           
            var spacing = new ConsoleText(" ");

            for (var row = grid.GetLength(1) - 1; row >= 0; row--)
            {
                for (var col = 0; col < grid.GetLength(0); col++)
                {
                    Print(grid[col, row]);
                    Print(spacing);
                }

                Console.WriteLine(ConsoleClearLineTillEnd());
            }

            var originalCursorTop = Console.CursorTop + 1;

            for (var row = originalCursorTop; row < Console.WindowHeight; row++)
                Console.WriteLine(ConsoleClearLineTillEnd());
            
            Console.SetCursorPosition(0, originalCursorTop);
            
            if (game.Player.Died)
                Console.WriteLine("Oh no Indiana, you have lost!");
            else if (game.Player.Won)
                Console.WriteLine("Congrats you have escaped the Temple of Doom!");

            if (game.Quit)
                Console.WriteLine("Stopping...");
        }

        private static void Print(ConsoleText consoleText)
        {
            Console.ForegroundColor = consoleText.ForegroundColor;
            Console.BackgroundColor = consoleText.BackgroundColor;
            Console.Write(consoleText.Text);
        }

        public static string ConsoleClearLineTillEnd()
        {
            return new string(' ', Console.WindowWidth-Console.CursorLeft);
        }
    }
}
