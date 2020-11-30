using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib
{
    public class Connection : IConnection
    {
        public Room Destination { get; }
        public Location Location { get; }
        
        public IItem Item { get; }

        public Connection(Room destination, Location location, IItem item = null)
        {
            Destination = destination;
            Location = location;
            Item = item;
        }
    }
}
