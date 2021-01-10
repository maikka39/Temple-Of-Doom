using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib.Tiles
{
    public class IceTile: Tile, IIceTile
    {
        public IceTile(int x, int y) : base(x, y)
        {
        }

        public new void OnEnter(IPlayer player, Direction? direction)
        {
            if (direction != null)
                player.Move((Direction) direction);
        }
    }
}
