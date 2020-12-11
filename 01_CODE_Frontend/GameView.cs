using CODE_GameLib;
using System;
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
            stringBuilder.AppendLine(GenericModule.HorizontalLine(Console.WindowWidth));
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(GetGrid(game));

            Console.Clear();
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(stringBuilder.ToString());
        }

        private static string GetGrid(IGame game)
        {
            var player = game.Player;
            var room = player.Location.Room;

            var grid = new char[room.Width + 2, room.Height + 2];

            InitializeGrid(grid);

            SetConnections(grid, room);

            SetItems(grid, room);

            SetPlayer(grid, player);

            return GridToString(grid);
        }

        private static string GridToString(char[,] grid)
        {
            var stringBuilder = new StringBuilder($"");
            for (var row = grid.GetLength(1)-1; row >= 0; row--)
            {
                for (var col = 0; col < grid.GetLength(0); col++)
                    stringBuilder.Append(grid[col, row] + " ");
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        private static void InitializeGrid(char[,] grid)
        {
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
        }

        private static void SetConnections(char[,] grid, IRoom room)
        {
            foreach (var connection in room.Connections)
            {
                var connChar = GetConnectionChar(connection);
                switch (connection.Direction)
                {
                    case Direction.Top:
                        grid[(grid.GetLength(0) + 1) / 2 - 1, 0] = connChar;
                        break;
                    case Direction.Right:
                        grid[grid.GetLength(0) - 1, (grid.GetLength(1) + 1) / 2 - 1] = connChar;
                        break;
                    case Direction.Bottom:
                        grid[(grid.GetLength(0) + 1) / 2 - 1, grid.GetLength(1) - 1] = connChar;
                        break;
                    case Direction.Left:
                        grid[0, (grid.GetLength(1) + 1) / 2 - 1] = connChar;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void SetItems(char[,] grid, IRoom room)
        {
            foreach (var item in room.Items)
                grid[item.X + 1, item.Y + 1] = GetCharForItem(item);
        }

        private static void SetPlayer(char[,] grid, IPlayer player)
        {
            grid[player.Location.X + 1, player.Location.Y + 1] = 'P';
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

            if (item.GetType() == typeof(Key))
                return 'K';

            if (item.GetType() == typeof(PressurePlate))
                return 'P';

            return '?';
        }
    }
}
