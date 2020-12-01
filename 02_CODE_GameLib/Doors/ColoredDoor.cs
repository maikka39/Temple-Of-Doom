using System.Drawing;
using CODE_GameLib.Interfaces.Items.Doors;

namespace CODE_GameLib.Items.Doors
{
    public class ColoredDoor : IColoredDoor
    {
        public bool Opened { get; set; }
        public Color Color { get; }

        public ColoredDoor(Color color)
        {
            Color = color;
        }
    }
}
