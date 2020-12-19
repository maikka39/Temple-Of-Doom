using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Interfaces
{
    public interface IConnection
    {
        public IRoom Room { get; }
        public IConnection Destination { get; set; }
        public Direction Direction { get; }
        public IDoor Door { get; }
        public int X { get; }
        public int Y { get; }
        bool TryEnter(IPlayer player, int playerX, int playerY);
    }
}
