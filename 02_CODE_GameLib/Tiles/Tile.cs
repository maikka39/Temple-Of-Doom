using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib.Tiles
{
    public abstract class Tile : RoomObject, ITile
    {
        protected Tile(int x, int y) : base(x, y)
        {
        }

        public void OnEnter(IPlayer player, Direction? direction)
        {
            throw new System.NotImplementedException();
        }
    }
}
