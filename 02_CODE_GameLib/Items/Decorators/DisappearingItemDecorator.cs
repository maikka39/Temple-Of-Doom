using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Items.Decorators
{
    /// <summary>
    /// Implements a disappearing item
    /// </summary>
    public class DisappearingItemDecorator : BaseItemDecorator, IWearable
    {
        public DisappearingItemDecorator(IItem decoratee) : base(decoratee)
        {
        }
        
        /// <summary>
        /// Executes the OnEnter method of the base class and then removes
        /// the item from the room
        /// </summary>
        /// <param name="player">The player standing on the trap</param>
        public override void OnEnter(IPlayer player)
        {
            base.OnEnter(player);
            player.Location.Room.RemoveItem(this);
        }
    }
}
