using System.Drawing;
using System.Linq;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Doors.Decorators
{
    /// <summary>
    /// Implements a door that can only be opened using a key with the
    /// same color as the door.
    /// </summary>
    public class ColoredDoorDecorator : BaseDoorDecorator, IColoredDoor
    {
        /// <summary>
        /// Creates a new instance from a door and color key
        /// </summary>
        /// <param name="decoratee">The door to decorate</param>
        /// <param name="color">The color of the key that is necessary to open the door</param>
        public ColoredDoorDecorator(IDoor decoratee, Color color) : base(decoratee)
        {
            Color = color;
        }

        /// <summary>
        /// Specifies the color of the key necessary to open the door
        /// </summary>
        public Color Color { get; }

        ///<inheritdoc/>
        public override bool CanEnter(IEntity entity)
        {
            if (!(entity is IPlayer player)) return false;

            if (player.Inventory.Where(item => item is IKey).Any(key => ((IKey) key).Color == Color))
                Opened = true;

            return base.CanEnter(player);
        }
    }
}
