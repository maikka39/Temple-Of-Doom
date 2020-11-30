using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class Connection : IConnection
    {
        public Room Destination { get; }
        public Location Location { get; }

        public Connection(Room destination, Location location)
        {
            Destination = destination;
            Location = location;
        }
    }
}
