using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Interfaces
{
    public interface IConnection
    {
        public IRoom Destination { get; }
        public Direction Direction { get; } 
        public IDoor Door { get; }
    }
}
