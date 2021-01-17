using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces.Tiles
{
    /// <summary>
    /// A tile on which an entity can stand
    /// </summary>
    public interface ITile : ILocation
    {
        /// <summary>
        /// Tells the tile an entity is standing on it
        /// </summary>
        /// <param name="entity">The entity standing on the tile</param>
        /// <returns>Whether the entity did anything as a result of the tile</returns>
        public bool OnEnter(IEntity entity);
    }
}
