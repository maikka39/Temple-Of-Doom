using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib.Tiles
{
    public abstract class Tile : InteractableRoomObject, ITile
    {
        protected Tile(int x, int y) : base(x, y)
        {
        }
    }
}
