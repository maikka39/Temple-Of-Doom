using CODE_GameLib.Interfaces.Items.BoobyTraps;

namespace CODE_GameLib.Items
{
    public class DisapearingTrap : IDisapearingTrap
    {
        public int X { get; }
        public int Y { get; }
        public int Damage { get; }
        
        public DisapearingTrap(int x, int y, int damage)
        {
            X = x;
            Y = y;
            Damage = damage;
        }
    }
}
