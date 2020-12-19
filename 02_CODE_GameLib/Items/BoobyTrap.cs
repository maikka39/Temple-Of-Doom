using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.BoobyTraps;

namespace CODE_GameLib.Items
{
    public class BoobyTrap : IBoobyTrap
    {
        public int X { get; }
        public int Y { get; }
        public int Damage { get; }

        public BoobyTrap(int x, int y, int damage)
        {
            X = x;
            Y = y;
            Damage = damage;
        }
        
        public void OnEnter(IPlayer player) => player.ReceiveDamage(Damage);
    }
}
