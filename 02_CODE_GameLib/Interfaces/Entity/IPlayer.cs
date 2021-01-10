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

        public void ReceiveDamage(int damage);

        public void AddToInventory(Wearable wearable);

        public void Move(Direction direction);
        
        public void ToggleCheat(Cheat cheat);
        public bool IsCheatEnabled(Cheat cheat);
    }
}
