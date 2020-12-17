using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib
{
    public class Room : IRoom
    {
        public int Width { get; }
        public int Height { get; }
        public List<IItem> Items { get; }
        public IEnumerable<IConnection> Connections { get; }

        public Room(int width, int height, List<IItem> items, IEnumerable<IConnection> connections)
        {
            Width = width;
            Height = height;
            Items = items;
            Connections = connections;
        }

        public IEnumerable<IDoor> Doors => Connections.Select(conn => conn.Door);

        public bool IsWithinBoundaries(int x, int y) => x >= 1 && x <= Width - 2 && y >= 1 && y <= Height - 2;
    }
}
