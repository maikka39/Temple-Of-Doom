using System.Collections;
using System.Collections.Generic;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Interfaces
{
    public interface IRoom
    {
        public int Width { get; }
        
        public int Height { get; }
        
        public IEnumerable<IItem> Items { get; set; }
        
        public IEnumerable<IConnection> Connections { get; }
    }
}