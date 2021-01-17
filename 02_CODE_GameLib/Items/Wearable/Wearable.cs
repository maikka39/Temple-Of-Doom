using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Items.Wearable
{
    /// <summary>
    /// Implements a wearable item
    /// </summary>
    public abstract class Wearable : Item
    {
        ///<inheritdoc/>
        protected Wearable(int x, int y) : base(x, y)
        {
        }

        /// <summary>
        /// Puts the item in the player inventory and removes it from the room
        /// </summary>
        /// <param name="player">The player which picks up the item</param>
        public override void OnEnter(IPlayer player)
        {
            player.AddToInventory(this);
            player.Location.Room.RemoveItem(this);
        }
    }
}
