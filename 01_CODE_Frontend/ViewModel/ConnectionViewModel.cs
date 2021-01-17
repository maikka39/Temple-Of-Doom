using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_Frontend.ViewModel
{
    public class ConnectionViewModel : IViewModel
    {
        private readonly IConnection _connection;

        /// <summary>
        /// Creates a new instances from a connection
        /// </summary>
        /// <param name="connection">The connection to create the view model for</param>
        public ConnectionViewModel(IConnection connection)
        {
            _connection = connection;
        }

        ///<inheritdoc/>
        public int X => _connection.X;
        
        ///<inheritdoc/>
        public int Y => _connection.Y;
        
        ///<inheritdoc/>
        public ConsoleText View => GetConnectionConsoleText(_connection);

        /// <summary>
        /// Gets the appropriate ConsoleText for a connection 
        /// </summary>
        /// <param name="connection">The entity to get the console text for</param>
        /// <returns>The console text for a connection</returns>
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
                    var consoleText = new ConsoleText("|", Utils.Color.ColorToConsoleColor(coloredDoor.Color));

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
