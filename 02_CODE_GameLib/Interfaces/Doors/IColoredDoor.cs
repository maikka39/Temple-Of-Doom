using System.Drawing;

namespace CODE_GameLib.Interfaces.Doors
{
    public interface IColoredDoor : IDoor
    {
        public Color Color { get; }
    }
}
