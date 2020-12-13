using CODE_GameLib;
using System;
using System.Text;
using CODE_Frontend.Modules;
using CODE_GameLib.Doors;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Items;
using CODE_GameLib.Items.Doors;

namespace CODE_Frontend
{
    public class GameView
    {
        private readonly HeaderModule _headerModule;

        public GameView()
        {
            _headerModule = new HeaderModule();
        }

        public void Update(Game game)
        {
            if (game.Quit)
                Console.WriteLine("Quitting game, goodbye!");

            var headingStringBuilder = new StringBuilder("");

            headingStringBuilder.AppendLine(_headerModule.Render(game));
            headingStringBuilder.AppendLine(GenericModule.HorizontalLine(Console.WindowWidth));
            headingStringBuilder.AppendLine();

            Console.Clear();
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(headingStringBuilder.ToString());

            PrintGrid(game);
        }

        private static void PrintGrid(IGame game)
        {
            var player = game.Player;
            var room = player.Location.Room;

            var grid = new ConsoleText[room.Width + 2, room.Height + 2];

            InitializeGrid(grid);

            SetConnections(grid, room);

            SetItems(grid, room);

            SetPlayer(grid, player);
            
            var spacing = new ConsoleText(" ");

            for (var row = grid.GetLength(1)-1; row >= 0; row--)
            {
                for (var col = 0; col < grid.GetLength(0); col++)
                {
                    Print(grid[col, row]);
                    Print(spacing);
                }
                Console.WriteLine();
            }
        }

        private static void InitializeGrid(ConsoleText[,] grid)
        {
            var wallConsoleText = new ConsoleText("#", ConsoleColor.Yellow);
            
            for (var col = 0; col < grid.GetLength(0); col++)
            {
                grid[col, 0] = wallConsoleText;
                grid[col, grid.GetLength(1) - 1] = wallConsoleText;

                var consoleText = new ConsoleText(" ");

                if (col == 0 || col == grid.GetLength(0) - 1)
                    consoleText = wallConsoleText;

                for (var row = 1; row < grid.GetLength(1) - 1; row++)
                    grid[col, row] = consoleText;
            }
        }

        private static void SetConnections(ConsoleText[,] grid, IRoom room)
        {
            foreach (var connection in room.Connections)
            {
                var connectionConsoleText = GetConnectionConsoleText(connection);
                switch (connection.Direction)
                {
                    case Direction.Top:
                        grid[(grid.GetLength(0) + 1) / 2 - 1, grid.GetLength(1) - 1] = connectionConsoleText;
                        break;
                    case Direction.Right:
                        grid[grid.GetLength(0) - 1, (grid.GetLength(1) + 1) / 2 - 1] = connectionConsoleText;
                        break;
                    case Direction.Bottom:
                        grid[(grid.GetLength(0) + 1) / 2 - 1, 0] = connectionConsoleText;
                        break;
                    case Direction.Left:
                        grid[0, (grid.GetLength(1) + 1) / 2 - 1] = connectionConsoleText;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void SetItems(ConsoleText[,] grid, IRoom room)
        {
            foreach (var item in room.Items)
                grid[item.X + 1, item.Y + 1] = GetItemConsoleText(item);
        }

        private static void SetPlayer(ConsoleText[,] grid, IPlayer player)
        {
            grid[player.Location.X + 1, player.Location.Y + 1] = new ConsoleText("P");
        }

        private static ConsoleText GetConnectionConsoleText(IConnection connection)
        {
            var doorType = connection.Door?.GetType();

            if (doorType == typeof(ClosingDoor))
            {
                return new ConsoleText("⋂");
            }

            if (doorType == typeof(ToggleDoor))
            {
                return new ConsoleText("⊥");
            }

            if (doorType == typeof(ColoredDoor))
            {
                var coloredDoor = (ColoredDoor) connection.Door;
                
                var consoleText = new ConsoleText("|", Util.ColorToConsoleColor(coloredDoor.Color));
                if (connection.Direction == Direction.Top || connection.Direction == Direction.Bottom)
                    consoleText.Text = "−";

                return consoleText;
            }

            return new ConsoleText(" ");
        }

        private static ConsoleText GetItemConsoleText(IItem item)
        {
            if (item.GetType() == typeof(SankaraStone))
                return new ConsoleText("S", ConsoleColor.DarkYellow);

            if (item.GetType() == typeof(BoobyTrap))
            {
                var character = "Ο";
                
                if (((BoobyTrap) item).Disappearing)
                    character = "@";
                
                return new ConsoleText(character, ConsoleColor.White);
            }
                

            if (item.GetType() == typeof(Key))
                return new ConsoleText("K", Util.ColorToConsoleColor(((IKey) item).Color));

            if (item.GetType() == typeof(PressurePlate))
                return new ConsoleText("T", ConsoleColor.White);

            return new ConsoleText("?");
        }

        public static void Print(ConsoleText consoleText)
        {
            Console.ForegroundColor = consoleText.ForegroundColor;
            Console.BackgroundColor = consoleText.BackgroundColor;
            Console.Write(consoleText.Text);
        }

        public static void PrintLn(ConsoleText consoleText)
        {
            Print(consoleText);
            Console.WriteLine();
        }
    }
}
