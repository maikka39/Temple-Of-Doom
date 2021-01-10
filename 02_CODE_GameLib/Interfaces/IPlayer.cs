using System.Collections.Generic;
using CODE_GameLib.Enums;
using CODE_GameLib.Items.Wearable;

namespace CODE_GameLib.Interfaces
{
    public interface IPlayer : IBaseObservable<IPlayer>
    {
        public IPlayerLocation Location { get; }

        public int Lives { get; }

        public bool Won { get; }

        public bool Died { get; }

        public IEnumerable<Wearable> Inventory { get; }
        
        public IEnumerable<Cheat> EnabledCheats { get; }

        public bool ReceiveDamage(int damage);

        public bool AddToInventory(Wearable wearable);

        public bool Move(Direction direction);
        public void ToggleCheat(Cheat cheat);
    }
}
