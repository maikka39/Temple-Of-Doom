using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_Frontend.ViewModel
{
    public class ConnectionViewModel
    {
        private readonly IConnection _connection;

        public ConnectionViewModel(IConnection connection)
        {
            _connection = connection;
        }

        public int X => _connection.X;
        public int Y => _connection.Y;
        public ConsoleText View => GetConnectionConsoleText(_connection);

        private static ConsoleText GetConnectionConsoleText(IConnection connection)
        {
            switch (connection.Door)
            {
                case IClosingDoor _:
                    return new ConsoleText("⋂");
                case IToggleDoor _:
                    return new ConsoleText("⊥");
                case IColoredDoor coloredDoor:
                {
                    var consoleText = new ConsoleText("|", Util.ColorToConsoleColor(coloredDoor.Color));

                    if (connection.Direction == Direction.North || connection.Direction == Direction.South)
                        consoleText.Text = "−";

                    return consoleText;
                }
                case ILadder _:
                    return new ConsoleText("↕");
                default:
                    return new ConsoleText(" ");
            }
        }
    }
}
