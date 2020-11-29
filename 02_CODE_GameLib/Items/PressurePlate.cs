using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public class PressurePlate : IPressurePlate
    {
        public int X { get; }
        public int Y { get; }
        public bool Pressed { get; set; }

        public PressurePlate(int x, int y, bool pressed)
        {
            X = x;
            Y = y;
            Pressed = pressed;
        }
    }
}