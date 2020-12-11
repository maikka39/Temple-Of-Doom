using CODE_GameLib;
using System;
using System.Text;
using CODE_Frontend.Modules;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_Frontend
{
    public class GameView
    {
        private readonly HeaderModule _headerModule;
        
        public GameView()
        {
            _headerModule = new HeaderModule();

            Console.WriteLine("Welcome to Temple of Doom!");
        }

        public void Update(Game game)
        {
            if (game.Quit)
                Console.WriteLine("Quitting game, goodbye!");
            
            var stringBuilder = new StringBuilder("");

            stringBuilder.AppendLine(_headerModule.Render(game));
            
            stringBuilder.AppendLine(GetGrid(game));
            
            Console.Clear();
            Console.SetCursorPosition(0,1);
            Console.WriteLine(stringBuilder.ToString());
        }

        private static string GetGrid(IGame game)
        {
            var room = game.Player.Location.Room;

            var grid = new char[room.Width, room.Height];
            
            for(var col = 0; col < grid.GetLength(0); col++)
                for(var row = 0; row < grid.GetLength(1); row++)
                    grid[col, row] =  ' ';

            foreach (var item in room.Items)
                grid[item.X, item.Y] = GetCharForItem(item);
            
            var stringBuilder = new StringBuilder("");
            stringBuilder.AppendLine(new string('#', room.Width + 2));
            for (var col = 0; col < grid.GetLength(0); col++)
            {
                stringBuilder.Append($"#");
                
                for (var row = 0; row < grid.GetLength(1); row++)
                    stringBuilder.Append(grid[col, row]);
                
                stringBuilder.AppendLine($"#");
            }
            stringBuilder.AppendLine(new string('#', room.Width + 2));
            
            var numLines = stringBuilder.Length - stringBuilder.ToString().Replace(Environment.NewLine, string.Empty).Length;
            
            for (var i = numLines; i < Console.WindowHeight; i++)
            {
                stringBuilder.AppendLine();
            }
            
            return stringBuilder.ToString();
        }

        private static char GetCharForItem(IItem item)
        {
            for (var i = 0; i < 100; i++)
                Console.WriteLine("Type:");
            Console.WriteLine(item.GetType());
            return 'K';
        }
    }
}
