using System.Drawing;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Items.Wearable
{
    public class Key : Wearable, IKey
    {
        public Color Color { get; }

        public Key(int x, int y, Color color) : base(x, y)
        {
            Color = color;
        }
    }
}
