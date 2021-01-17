using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib.Tiles
{
    /// <summary>
    /// Implements a base tile on which an entity can stand
    /// </summary>
    public abstract class Tile : Location, ITile
    {
        ///<inheritdoc/>
        protected Tile(ILocation location) : base(location)
        {
        }

        ///<inheritdoc/>
        public virtual bool OnEnter(IEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
