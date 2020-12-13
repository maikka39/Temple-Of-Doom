using System.Drawing;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Interfaces.Items.Doors
{
    public interface IColoredDoor : IDoor
    {
        public Color Color { get; }
    }
}
