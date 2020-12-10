using System.Drawing;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.Doors;

namespace CODE_GameLib.Doors
{
    public class ColoredDoor : IColoredDoor
    {
        public bool Opened { get; set; }
        public Color Color { get; }
        
        public ColoredDoor(Color color)
        {
            Color = color;
        }
        
        public bool PassThru(IPlayer player)
        {
            if (player.Keys.Any(key => key.Color == Color))
                Opened = true;
            return Opened;
        }
    }
}
