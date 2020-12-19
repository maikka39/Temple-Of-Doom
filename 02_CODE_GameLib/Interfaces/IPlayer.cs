using CODE_GameLib.Interfaces.Items.Wearable;
using System.Collections.Generic;
using CODE_GameLib.Items;

namespace CODE_GameLib.Interfaces
{
    public interface IPlayer : IBaseObservable<IPlayer>
    {
        public IPlayerLocation Location { get; }

        public int Lives { get; }

        public bool Won { get; }

        public bool Died { get; }

        public IEnumerable<Wearable> Inventory { get; }

        public bool ReceiveDamage(int damage);

        public bool AddToInventory(Wearable wearable);

        public bool Move(Direction direction);
    }
}
