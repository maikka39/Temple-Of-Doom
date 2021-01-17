using System.Drawing;

namespace CODE_GameLib.Interfaces.Items.Wearable
{
    /// <summary>
    /// A key for a door
    /// </summary>
    public interface IKey : IItem, IWearable
    {
        /// <summary>
        /// Specifies the color of the key
        /// </summary>
        public Color Color { get; }
    }
}
