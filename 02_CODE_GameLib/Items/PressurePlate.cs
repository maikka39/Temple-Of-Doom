using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public class PressurePlate : Item, IPressurePlate
    {
        public PressurePlate(int x, int y) : base(x, y)
        {
        }
        
        public new void OnEnter(IPlayer player)
        {
            foreach (var connection in player.Location.Room.Connections.Where(conn => conn.Door is IToggleDoor))
                connection.Door.Opened = !connection.Door.Opened;
        }
    }
}
