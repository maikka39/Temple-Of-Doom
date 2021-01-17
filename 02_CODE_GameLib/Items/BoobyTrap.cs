using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.BoobyTraps;

namespace CODE_GameLib.Items
{
    public class BoobyTrap : Item, IBoobyTrap
    {
        private readonly int _damage;

        public BoobyTrap(int x, int y, int damage) : base(x, y)
        {
            _damage = damage;
        }

        public override void OnEnter(IPlayer player)
        {
            player.ReceiveDamage(_damage);
        }
    }
}
