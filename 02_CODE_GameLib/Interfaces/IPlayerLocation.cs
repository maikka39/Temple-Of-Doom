namespace CODE_GameLib.Interfaces
{
    public interface IPlayerLocation
    {
        public IRoom Room { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}