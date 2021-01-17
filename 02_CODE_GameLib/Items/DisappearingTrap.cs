using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.BoobyTraps;

namespace CODE_GameLib.Items
{
    /// <summary>
    /// Implements a disappearing item
    /// </summary>
    public class DisappearingTrap : BoobyTrap, IDisappearingTrap
    {
        ///<inheritdoc/>
        public DisappearingTrap(int x, int y, int damage) : base(x, y, damage)
        {
        }

        /// <summary>
        /// Executes the OnEnter method of the base class and then
        /// removes the item from the room
        /// </summary>
        /// <param name="player">The player standing on the trap</param>
        public override void OnEnter(IPlayer player)
        {
            base.OnEnter(player);
            player.Location.Room.RemoveItem(this);
        }
    }
}
