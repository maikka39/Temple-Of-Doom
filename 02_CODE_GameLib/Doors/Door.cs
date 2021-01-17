using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors
{
    /// <summary>
    /// A basic door class for a connection. It checks whether an entity
    /// can pass through a door
    /// </summary>
    public sealed class Door : IDoor
    {
        ///<inheritdoc/>
        public bool Opened { get; set; }

        ///<inheritdoc/>
        public bool CanEnter(IEntity entity)
        {
            return CanBypass(entity) || Opened;
        }

        /// <summary>
        /// Checks if an entity can bypass the door
        /// </summary>
        /// <param name="entity">The entity to check for</param>
        /// <returns>Whether the entity can bypass the door</returns>
        private static bool CanBypass(IEntity entity)
        {
            if (entity is IPlayer player)
                return player.IsCheatEnabled(Cheat.IgnoreDoors);

            return false;
        }
    }
}
