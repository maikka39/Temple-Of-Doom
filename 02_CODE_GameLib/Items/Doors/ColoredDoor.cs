using System.Drawing;
using CODE_GameLib.Interfaces.Items.Doors;

namespace CODE_GameLib.Items.Doors
{
    public class ColoredDoor : IDoor
    {
        public int X { get; }
        public int Y { get; }
        public bool Opened { get; set; }
        public Color Color { get; }

        public ColoredDoor(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
