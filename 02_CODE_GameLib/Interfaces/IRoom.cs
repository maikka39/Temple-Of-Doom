using CODE_GameLib.Interfaces.Items;
using System.Collections.Generic;

namespace CODE_GameLib.Interfaces
{
    public interface IRoom
    {
        public int Width { get; }

        public int Height { get; }

        public List<IItem> Items { get; set; }

        public IEnumerable<IConnection> Connections { get; }
    }
}