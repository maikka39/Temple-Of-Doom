using System.Linq;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    /// <summary>
    /// Implements a pressure plate
    /// </summary>
    public class PressurePlate : Item, IPressurePlate
    {
        ///<inheritdoc/>
        public PressurePlate(int x, int y) : base(x, y)
        {
        }

        /// <summary>
        /// Is executed when a player enters the pressure plate.
        /// Opens all toggle doors in the room
        /// </summary>
        /// <param name="player">The player standing on the pressure plate</param>
        public override void OnEnter(IPlayer player)
        {
            foreach (var connection in player.Location.Room.Connections.Where(conn => conn.Door is IToggleDoor))
                connection.Door.Opened = !connection.Door.Opened;
        }
    }
}
