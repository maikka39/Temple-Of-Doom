using System.Collections.Generic;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib
{
    public class Room : IRoom
    {
        public int Width { get; }
        public int Height { get; }
        public IEnumerable<IItem> Items { get; set; }
        public IEnumerable<IConnection> Connections { get; }

        public Room(int width, int height, IEnumerable<IItem> items, IEnumerable<IConnection> connections)
        {
            Width = width;
            Height = height;
            Items = items;
            Connections = connections;
        }
    }
}