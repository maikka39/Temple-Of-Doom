using System.Drawing;
using System.Linq;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Doors.Decorators
{
    public class ColoredDoorDecorator : BaseDoorDecorator, IColoredDoor
    {
        public ColoredDoorDecorator(IDoor decoratee, Color color) : base(decoratee)
        {
            Color = color;
        }

        public Color Color { get; }

        public override bool CanEnter(IEntity entity)
        {
            if (!(entity is IPlayer player)) return false;

            if (player.Inventory.Where(item => item is IKey).Any(key => ((IKey) key).Color == Color))
                Opened = true;

            return base.CanEnter(player);
        }
    }
}
