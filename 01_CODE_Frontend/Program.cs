using System;
using System.Text;
using CODE_GameLib;
using CODE_PersistenceLib;

namespace CODE_Frontend
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.CursorVisible = false;

            var game = GameReader.Read(@"./Levels/TempleOfDoom.json");

            var gameView = new GameView();
            game.Updated += (sender, game) => gameView.Update(game);
            
            gameView.Update(game);
            
            while (!game.Quit)
            {
                var keyPressed = Console.ReadKey().Key;
                Console.Write("\b");
                
                var tickData = new TickData();
                
                // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
                switch (keyPressed)
                {
                    case ConsoleKey.K:
                        tickData.MovePlayer = Direction.Top;
                        break;
                    
                    case ConsoleKey.J:
                        tickData.MovePlayer = Direction.Bottom;
                        break;
                    
                    case ConsoleKey.H:
                        tickData.MovePlayer = Direction.Left;
                        break;
                    
                    case ConsoleKey.L:
                        tickData.MovePlayer = Direction.Right;
                        break;
                    
                    case ConsoleKey.Escape:
                        tickData.Quit = true;
                        break;
                }
                
                game.Tick(tickData);
            }

        }
    }
}
