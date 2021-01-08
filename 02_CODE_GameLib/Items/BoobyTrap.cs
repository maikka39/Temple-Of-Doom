using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.BoobyTraps;

namespace CODE_GameLib.Items
{
    public class BoobyTrap : Item, IBoobyTrap
    {
        public int Damage { get; }

        public BoobyTrap(int x, int y, int damage) : base(x, y)
        {
            Damage = damage;
        }

        public new void OnEnter(IPlayer player)
        {
            player.ReceiveDamage(Damage);
        }
    }
}
