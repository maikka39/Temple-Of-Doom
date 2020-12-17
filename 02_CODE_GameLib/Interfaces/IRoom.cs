using CODE_GameLib.Interfaces.Items;
using System.Collections.Generic;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Interfaces
{
    public interface IRoom
    {
        public int Width { get; }

        public int Height { get; }

        public List<IItem> Items { get; }

        public IEnumerable<IConnection> Connections { get; }
        
        public IEnumerable<IDoor> Doors { get; }

        public bool IsWithinBoundaries(int x, int y);
    }
}
