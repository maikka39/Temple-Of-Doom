using System;
using System.Text;
using CODE_PersistenceLib;

namespace CODE_Frontend
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WindowWidth = 200;
            Console.WindowHeight = 50;
            Console.CursorVisible = false;

            var game = GameReader.Read(@"./Levels/TempleOfDoom.json");

            var gameView = new GameView();
            game.Updated += (sender, game) => gameView.Draw(game);
            game.Run();
        }
    }
}