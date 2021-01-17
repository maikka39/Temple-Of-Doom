using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib.Tiles
{
    /// <summary>
    /// Implements an ice tile, slides the player forwards
    /// </summary>
    public class IceTile : Tile, IIceTile
    {
        public IceTile(int x, int y) : base(x, y)
        {
        }

        /// <summary>
        /// Slides the entity forwards
        /// </summary>
        /// <param name="entity">The entity that moved to this tile</param>
        /// <returns>Whether the entity moved or not</returns>
        public override bool OnEnter(IEntity entity)
        {
            if (entity.Location.LastDirection == null)
                return false;
            
            return entity.Move((Direction) entity.Location.LastDirection);
        }
    }
}
