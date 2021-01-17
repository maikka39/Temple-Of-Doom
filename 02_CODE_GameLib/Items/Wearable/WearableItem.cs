using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Items.Wearable
{
    /// <summary>
    /// Implements a wearable item
    /// </summary>
    public abstract class WearableItem : Item, IWearable
    {
        protected WearableItem(ILocation location) : base(location)
        {
        }
        
        /// <summary>
        /// Puts the item in the player inventory and removes it from the room
        /// </summary>
        public override void OnEnter(IPlayer player)
        {
            player.AddToInventory(this);
            player.Location.Room.RemoveItem(this);
        }
    }
}
