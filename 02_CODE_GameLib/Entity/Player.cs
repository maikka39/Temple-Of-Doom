using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.Wearable;
using CODE_GameLib.Items.Wearable;

namespace CODE_GameLib.Entity
{
    public class Player : Entity, IPlayer
    {
        private readonly List<Wearable> _inventory;
        private readonly List<Cheat> _enabledCheats = new List<Cheat>();
        
        public bool Won => Inventory.Count(wearable => wearable is ISankaraStone) >= 5;

        public IEnumerable<Wearable> Inventory => _inventory;
        
        public IEnumerable<Cheat> EnabledCheats => _enabledCheats;

        public Player(int lives, List<Wearable> inventory,
            IEntityLocation location) : base(lives, location)
        {
            _inventory = inventory;
        }

        public override void ReceiveDamage(int damage)
        {
            if (IsCheatEnabled(Cheat.Invincible))
                return;
            
            base.ReceiveDamage(damage);
        }

        public void AddToInventory(Wearable wearable)
        {
            _inventory.Add(wearable);
            NotifyObservers(this);
        }

        public void ToggleCheat(Cheat cheat)
        {
            if (_enabledCheats.Contains(cheat))
                _enabledCheats.Remove(cheat);
            else
                _enabledCheats.Add(cheat);
        }

        public bool IsCheatEnabled(Cheat cheat)
        {
            return EnabledCheats.Any(enabledCheat => enabledCheat == cheat);
        }

        public void Shoot()
        {
            var enemies = Location.Room.GetEnemiesWithinReach(Location);
            
            // Enemies is converted to a list as the original collection might change when enemies die
            enemies.ToList().ForEach(enemy => enemy.ReceiveDamage(1));
        }
    }
}
