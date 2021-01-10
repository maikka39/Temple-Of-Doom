using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items.Wearable
{
    public abstract class Wearable : Item, IItem
    {
        protected Wearable(int x, int y) : base(x, y)
        {
        }
        
        public new void OnEnter(IPlayer player)
        {
            player.AddToInventory(this);
            player.Location.Room.RemoveItem(this);
        }
    }
}
