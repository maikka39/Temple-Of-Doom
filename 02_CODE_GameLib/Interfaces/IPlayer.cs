using System.Collections.Generic;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Interfaces
{
    public interface IPlayer
    {
        public IPlayerLocation Location { get; }
        
        public int Lives { get; set; }
        
        public List<IWearable> Inventory { get; set; }

        public bool Move(Direction direction);
    }
}
