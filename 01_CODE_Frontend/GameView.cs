using CODE_GameLib;
using System;
using System.Linq;
using System.Text;
using CODE_Frontend.Modules;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Items;

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
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(stringBuilder.ToString());
        }

        private static string GetGrid(IGame game)
        {
            var room = game.Player.Location.Room;

            var grid = new char[room.Width + 2, room.Height + 2];

            for (var col = 0; col < grid.GetLength(0); col++)
            {
                var character = ' ';

                if (col == 0 || col == grid.GetLength(0) - 1)
                    character = '#';

                grid[col, 0] = '#';
                grid[col, grid.GetLength(1) - 1] = '#';

                for (var row = 1; row < grid.GetLength(1) - 1; row++)
                    grid[col, row] = character;
            }

            foreach (var item in room.Items)
                grid[item.X + 1, item.Y + 1] = GetCharForItem(item);

            foreach (var connection in room.Connections)
            {
                switch (connection.Direction)
                {
                    case Direction.Top:
                        grid[0, (grid.GetLength(1) + 1) / 2 - 1] = GetConnectionChar(connection);
                        break;
                    case Direction.Right:
                        grid[(grid.GetLength(0) + 1) / 2 - 1, grid.GetLength(1) - 1] = GetConnectionChar(connection);
                        break;
                    case Direction.Bottom:
                        grid[grid.GetLength(0) - 1, (grid.GetLength(1) + 1) / 2 - 1] = GetConnectionChar(connection);
                        break;
                    case Direction.Left:
                        grid[(grid.GetLength(0) + 1) / 2 - 1, 0] = GetConnectionChar(connection);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var stringBuilder = new StringBuilder($"");
            for (var col = 0; col < grid.GetLength(0); col++)
            {
                for (var row = 0; row < grid.GetLength(1); row++)
                    stringBuilder.Append(grid[col, row] + " ");
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        private static char GetConnectionChar(IConnection connection)
        {
            return '|';
        }

        private static char GetCharForItem(IItem item)
        {
            if (item.GetType() == typeof(SankaraStone))
                return 'S';

            if (item.GetType() == typeof(BoobyTrap))
                return 'B';

            return '#';
        }
    }
}
