using CODE_PersistenceLib;
using System;

namespace CODE_Frontend
{
    internal static class Program
    {
        private static void Main()
        {
            while (true)
            {
                var game = GameReader.Read(@"./Levels/TempleOfDoom.json");

                var gameView = new GameView();
                game.Updated += (sender, game) => gameView.Update(game);

                gameView.Update(game);

                while (!game.Quit)
                {
                    var key = Console.ReadKey().Key;
                    Console.Write("\b");
                    game.Tick(Input.HandleKey(key));
                }

                Console.WriteLine("Please hit any key to restart or escape to quit...");
                var closeKey = Console.ReadKey().Key;
                if (closeKey != ConsoleKey.Escape) continue;
                Console.WriteLine("QQuitting game, goodbye!");
                break;
            }
        }
    }
}
