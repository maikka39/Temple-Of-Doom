using CODE_GameLib;
using CODE_GameLib.Doors;
using CODE_GameLib.Interfaces.Items.Doors;
using CODE_GameLib.Items.Doors;

namespace CODE_Frontend.ViewModel
{
    public class DoorViewModel
    {
        private readonly IDoor _door;
        private readonly Direction _direction;

        public ConsoleText View => GetDoorConsoleText(_door, _direction);

        public DoorViewModel(IDoor door, Direction direction)
        {
            _door = door;
            _direction = direction;
        }
        
        private static ConsoleText GetDoorConsoleText(IDoor door, Direction direction)
        {
            switch (door)
            {
                case ClosingDoor _:
                    return new ConsoleText("⋂");
                case ToggleDoor _:
                    return new ConsoleText("⊥");
                case ColoredDoor coloredDoor:
                {
                    var consoleText = new ConsoleText("|", Util.ColorToConsoleColor(coloredDoor.Color));
                    
                    if (direction == Direction.Top || direction == Direction.Bottom)
                        consoleText.Text = "−";

                    return consoleText;
                }
                default:
                    return new ConsoleText(" ");
            }
        }
    }
}
