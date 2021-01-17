using System.Drawing;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Items.Wearable
{
    /// <summary>
    /// Implements a key to pass through a door
    /// </summary>
    public class Key : WearableItem, IKey
    {
        /// <summary>
        /// Creates a new instance from the passed parameters
        /// </summary>
        /// <param name="location">The location of the item</param>
        /// <param name="color">The color of the key</param>
        public Key(ILocation location, Color color) : base(location)
        {
            Color = color;
        }

        ///<inheritdoc/>
        public Color Color { get; }
    }
}
