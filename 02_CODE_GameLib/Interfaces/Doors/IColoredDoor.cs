using System.Drawing;

namespace CODE_GameLib.Interfaces.Doors
{
    /// <summary>
    /// A door which needs a key to be opened
    /// </summary>
    public interface IColoredDoor : IDoor
    {
        /// <summary>
        /// Specifies the color of the key necessary to open this door
        /// </summary>
        public Color Color { get; }
    }
}
