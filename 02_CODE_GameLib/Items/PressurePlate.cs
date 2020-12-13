using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public class PressurePlate : IPressurePlate
    {
        public int X { get; }
        public int Y { get; }

        public PressurePlate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
