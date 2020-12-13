using System.Collections.Generic;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Interfaces
{
    public interface IPlayer : IBaseObservable<IPlayer>
    {
        public IPlayerLocation Location { get; }
        
        public int Lives { get; }
        
        public bool Died { get; }
        
        public List<IWearable> Inventory { get; }

        public bool RecieveDamage(int damage);

        public bool Move(Direction direction);
    }
}
