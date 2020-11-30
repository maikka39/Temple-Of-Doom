using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.Doors;

namespace CODE_GameLib
{
    public class Connection : IConnection
    {
        public Room Destination { get; }
        public Location Location { get; }
        
        public IDoor Item { get; }

        public Connection(Room destination, Location location, IDoor item = null)
        {
            Destination = destination;
            Location = location;
            Item = item;
        }
    }
}
