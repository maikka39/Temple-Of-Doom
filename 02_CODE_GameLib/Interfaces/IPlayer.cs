using CODE_GameLib.Interfaces.Items.Wearable;
using System.Collections.Generic;

namespace CODE_GameLib.Interfaces
{
    public interface IPlayer : IBaseObservable<IPlayer>
    {
        public IPlayerLocation Location { get; }

        public int Lives { get; }

        public bool Won { get; }

        public bool Died { get; }

        public IEnumerable<IWearable> Inventory { get; }

        public bool RecieveDamage(int damage);

        public bool AddToInventory(IWearable wearable);

        public bool Move(Direction direction);
    }
}
