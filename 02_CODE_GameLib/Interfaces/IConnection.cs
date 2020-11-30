using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Interfaces
{
    public interface IConnection
    {
        public Room Destination { get; }
        public Location Location { get; } 
        public IItem Item { get; }
    }
}
