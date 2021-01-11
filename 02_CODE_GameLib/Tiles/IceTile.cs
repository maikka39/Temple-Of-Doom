using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib.Tiles
{
    public class IceTile : Tile, IIceTile
    {
        public IceTile(int x, int y) : base(x, y)
        {
        }

        public override void OnEnter(IEntity entity, Direction? direction)
        {
            if (direction != null)
                entity.Move((Direction) direction);
        }
    }
}
