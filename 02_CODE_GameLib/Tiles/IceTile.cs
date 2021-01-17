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

        public override bool OnEnter(IEntity entity)
        {
            if (entity.Location.LastDirection == null)
                return false;
            
            return entity.Move((Direction) entity.Location.LastDirection);
        }
    }
}
