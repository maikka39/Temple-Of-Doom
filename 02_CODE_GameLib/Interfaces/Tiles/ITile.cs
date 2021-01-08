namespace CODE_GameLib.Interfaces.Tiles
{
    public interface ITile
    {
        public int X { get; }
        public int Y { get; }

        public void OnEnter(IPlayer player);
    }
}
