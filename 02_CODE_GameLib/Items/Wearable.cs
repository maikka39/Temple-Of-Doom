using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public abstract class Wearable : IItem
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public void OnEnter(IPlayer player)
        {
            player.AddToInventory(this);
            player.Location.Room.RemoveItem(this);
        }
    }
}
