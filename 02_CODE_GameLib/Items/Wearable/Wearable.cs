using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Items.Wearable
{
    public abstract class Wearable : Item
    {
        protected Wearable(int x, int y) : base(x, y)
        {
        }

        public override void OnEnter(IPlayer player)
        {
            player.AddToInventory(this);
            player.Location.Room.RemoveItem(this);
        }
    }
}
