using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Items.Doors;

namespace CODE_GameLib
{
    public class Connection : IConnection
    {
        public IRoom Destination { get; }
        public Direction Direction { get; }
        
        public IDoor Door { get; }

        public Connection(IRoom destination, Direction direction, IDoor door = null)
        {
            Destination = destination;
            Direction = direction;
            Door = door;
        }
    }
}
