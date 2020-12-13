using CODE_PersistenceLib;
using System;

namespace CODE_Frontend
{
    internal static class Program
    {
        private static void Main()
        {
            var game = GameReader.Read(@"./Levels/TempleOfDoom.json");

            var gameView = new GameView();
            game.Updated += (sender, game) => gameView.Update(game);

            gameView.Update(game);

            while (!game.Quit)
            {
                var keyPressed = Console.ReadKey().Key;
                Console.Write("\b");

                game.Tick(Input.HandleKey(keyPressed));
            }
        }
    }
}
