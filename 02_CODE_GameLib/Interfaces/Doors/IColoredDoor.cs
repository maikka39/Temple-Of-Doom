using System.Drawing;

namespace CODE_GameLib.Interfaces.Items.Doors
{
    public interface IColoredDoor : IDoor
    {
        public Color Color { get; }
    }
}
