using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces
{
    /// <summary>
    /// Connection between rooms/locations
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Specifies the room in which the connection lives
        /// </summary>
        public IRoom Room { get; }
        
        /// <summary>
        /// Specifies the connection destination, the other side of the connection
        /// </summary>
        public IConnection Destination { get; set; }
        
        /// <summary>
        /// Specifies the direction in which the connection goes
        /// </summary>
        public Direction Direction { get; }
        
        /// <summary>
        /// The door on the connection, holds the logic for checking whether ab entity can enter the connection
        /// </summary>
        public IDoor Door { get; }
        
        /// <summary>
        /// X location of the connection
        /// </summary>
        public int X { get; }
        
        /// <summary>
        /// Y location of the connection
        /// </summary>
        public int Y { get; }
        
        /// <summary>
        /// Checks if the passed entity can enter the connection, and if so, enters it.
        /// </summary>
        /// <param name="entity">The entity which tries to enter the connection</param>
        /// <param name="location">The location to which the entity wishes to move</param>
        /// <returns>Whether the user entered the connection or not.</returns>
        bool TryEnter(IEntity entity, ILocation location);
    }
}
