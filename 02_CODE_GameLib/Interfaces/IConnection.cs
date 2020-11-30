using CODE_GameLib.Interfaces.Items.Doors;

namespace CODE_GameLib.Interfaces
{
    public interface IConnection
    {
        public IRoom Destination { get; }
        public Location Location { get; } 
        public IDoor Item { get; }
    }
}
