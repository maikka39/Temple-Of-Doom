using System.Collections.Generic;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_GameLib.Interfaces
{
    /// <summary>
    /// A room in which an entity can move around and pick things up
    /// </summary>
    public interface IRoom
    {
        /// <summary>
        /// Specifies the width of the room
        /// </summary>
        public int Width { get; }
        
        /// <summary>
        /// Specifies the height of the room
        /// </summary>
        public int Height { get; }
        
        /// <summary>
        /// A list which holds all items in the room
        /// </summary>
        public List<IItem> Items { get; }
        
        /// <summary>
        /// A list which holds all tiles in the room
        /// </summary>
        public List<ITile> Tiles { get; }
        
        /// <summary>
        /// A list which holds all enemies in the room
        /// </summary>
        public List<IEnemy> Enemies { get; }
        
        /// <summary>
        /// A list which hold all connections in the room
        /// </summary>
        public IEnumerable<IConnection> Connections { get; }
        
        /// <summary>
        /// Checks whether a location is withing the room
        /// </summary>
        /// <param name="x">The x coordinate to check</param>
        /// <param name="y">The y coordinate to check</param>
        /// <returns>Whether the location is within the room</returns>
        public bool IsWithinBoundaries(ILocation location);
        
        /// <summary>
        /// Removes an item from the room
        /// </summary>
        /// <param name="item">The item to remove</param>
        public void RemoveItem(IItem item);
        
        /// <summary>
        /// Tells the room it has to update
        /// </summary>
        /// <returns>Whether anything has updated</returns>
        public bool Update();
        
        /// <summary>
        /// Checks whether the passed entity can do anything in the room
        /// </summary>
        /// <param name="entity">The entity to check for</param>
        public void Check(IEntity entity);

        /// <summary>
        /// Checks whether the passed player hits an enemy, if so, deals damage
        /// </summary>
        /// <param name="player">The player to check for</param>
        public void CheckEnemies(IPlayer player);
        
        /// <summary>
        /// Retrieves all enemies withing reach of a location
        /// </summary>
        /// <param name="location">The location to check around</param>
        /// <returns>A collection of enemies</returns>
        public IEnumerable<IEnemy> GetEnemiesWithinReach(IEntityLocation location);
        
        /// <summary>
        /// Removes an enemy from the room
        /// </summary>
        /// <param name="enemy">The enemy to remove</param>
        public void RemoveEnemy(IEnemy enemy);
    }
}
