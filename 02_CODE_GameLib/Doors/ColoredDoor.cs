using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.Wearable;
using System.Drawing;
using System.Linq;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors
{
    public class ColoredDoor : Door, IColoredDoor
    {
        public Color Color { get; }

        public ColoredDoor(Color color)
        {
            Color = color;
        }

        public new bool CanEnter(IPlayer player)
        {
            if (player.Inventory.Where(item => item is IKey).Any(key => ((IKey)key).Color == Color))
                Opened = true;
            
            return base.CanEnter(player);
        }
    }
}
