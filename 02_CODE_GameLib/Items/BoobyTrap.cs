using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.BoobyTraps;

namespace CODE_GameLib.Items
{
    public class BoobyTrap : Item, IBoobyTrap
    {
        public BoobyTrap(int x, int y, int damage) : base(x, y)
        {
            Damage = damage;
        }

        public int Damage { get; }

        public override void OnEnter(IPlayer player)
        {
            player.ReceiveDamage(Damage);
        }
    }
}
