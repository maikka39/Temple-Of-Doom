using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib.Tiles
{
    public abstract class Tile : ITile
    {
        public int X { get; }
        public int Y { get; }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public void OnEnter(IPlayer player)
        {
            throw new System.NotImplementedException();
        }
    }
}
