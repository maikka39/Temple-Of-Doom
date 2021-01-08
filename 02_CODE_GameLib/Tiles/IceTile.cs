using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib.Tiles
{
    public class IceTile: Tile, IIceTile
    {
        public IceTile(int x, int y) : base(x, y)
        {
        }
    }
}
