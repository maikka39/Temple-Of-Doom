using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.BoobyTraps;

namespace CODE_GameLib.Items
{
    public class DisappearingTrap : BoobyTrap, IDisappearingTrap
    {
        public DisappearingTrap(int x, int y, int damage) : base(x, y, damage)
        {
        }
        
        public new void OnEnter(IPlayer player)
        {
            base.OnEnter(player);
            player.Location.Room.RemoveItem(this);
        }
    }
}
