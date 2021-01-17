using System;
using CODE_GameLib.Enums;

namespace CODE_GameLib.Interfaces
{
    /// <summary>
    /// The location of an entity
    /// </summary>
    public interface IEntityLocation : IObservable<IEntityLocation>
    {
        /// <summary>
        /// Specifies the room
        /// </summary>
        public IRoom Room { get; }
        
        /// <summary>
        /// Specifies the x coordinate
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Specifies the x coordinate
        /// </summary>
        public int Y { get; }
        
        /// <summary>
        /// Specifies the last direction in which the entity moved
        /// </summary>
        public Direction? LastDirection { get; }
        
        /// <summary>
        /// Updates the location
        /// </summary>
        /// <param name="room">The new room</param>
        /// <param name="x">The new x coordinate</param>
        /// <param name="y">The new y coordinate</param>
        /// <param name="direction">The direction in which the entity goes</param>
        public void Update(IRoom room, int x, int y, Direction? direction = null);
    }
}
