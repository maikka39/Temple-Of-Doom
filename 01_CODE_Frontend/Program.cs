using CODE_PersistenceLib;
using System;
using System.Text;

namespace CODE_Frontend
{
    internal static class Program
    {
        private static void Main()
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

                game.Tick(Input.HandleKey(keyPressed));
            }
        }
    }
}
