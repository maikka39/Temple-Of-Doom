using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public class BoobyTrap : IBoobyTrap
    {
        public int X { get; }
        public int Y { get; }
        public int Damage { get; }
        public bool Disappearing { get; }

        public BoobyTrap(int x, int y, int damage, bool disappearing)
        {
            X = x;
            Y = y;
            Damage = damage;
            Disappearing = disappearing;
        }
    }
}