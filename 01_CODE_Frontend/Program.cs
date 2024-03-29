﻿using System;
using CODE_PersistenceLib;

namespace CODE_Frontend
{
    internal static class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.Clear();

                var game = GameReader.Read(@"./Levels/TempleOfDoom_Extended_A.json");

                var gameView = new GameView();
                game.Updated += (uSender, uGame) => gameView.Update(uGame);

                gameView.Update(game);

                while (!game.Quit)
                {
                    var key = Console.ReadKey().Key;
                    Console.Write("\b"); // Remove the entered character
                    game.Tick(Input.HandleKey(key));
                }

                Console.WriteLine("Please hit any key to restart or escape to quit...");
                var closeKey = Console.ReadKey().Key;
                if (closeKey == ConsoleKey.Escape) break;
            }

            Console.WriteLine("QQuitting game, goodbye!");
            Console.Clear();
        }
    }
}
