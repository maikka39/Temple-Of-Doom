using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces.Doors
{
    /// <summary>
    /// A door for a connection, hold the logic for checking whether an entity can enter it 
    /// </summary>
    public interface IDoor
    {
        /// <summary>
        /// Specifies whether the door is opened
        /// </summary>
        public bool Opened { get; set; }

        /// <summary>
        /// Checks whether the specified entity can pass through the door
        /// </summary>
        /// <param name="entity">The entity which tries to enter the door</param>
        /// <returns>Whether the entity can pass through the door</returns>
        public bool CanEnter(IEntity entity);
    }
}
