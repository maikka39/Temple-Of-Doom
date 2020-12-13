using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.Doors;

namespace CODE_GameLib.Items
{
    public class PressurePlate : IPressurePlate
    {
        public int X { get; }
        public int Y { get; }
        public IDoor Door { get; set; }

        public PressurePlate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
