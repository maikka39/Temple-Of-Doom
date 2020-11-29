namespace CODE_GameLib.Interfaces
{
    public interface IConnection
    {
        public Room Destination { get; }
        public Direction Direction { get; } 
    }
}