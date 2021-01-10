using System.Collections.Generic;
using CODE_GameLib.Enums;
using CODE_GameLib.Items.Wearable;

namespace CODE_GameLib.Interfaces.Entity
{
    public interface IPlayer : IEntity
    {
        public bool Won { get; }
        public IEnumerable<Wearable> Inventory { get; }
        public IEnumerable<Cheat> EnabledCheats { get; }
        public void AddToInventory(Wearable wearable);
        public void ToggleCheat(Cheat cheat);
        public bool IsCheatEnabled(Cheat cheat);
    }
}
