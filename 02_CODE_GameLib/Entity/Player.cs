using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.Wearable;
using CODE_GameLib.Items.Wearable;

namespace CODE_GameLib.Entity
{
    /// <summary>
    /// Implements a player of the game
    /// </summary>
    public class Player : Entity, IPlayer
    {
        private readonly List<Cheat> _enabledCheats = new List<Cheat>();
        private readonly List<Wearable> _inventory;

        /// <summary>
        /// Creates a new instance of a player based on the passed parameters
        /// </summary>
        /// <param name="lives">The amount of lives of the player</param>
        /// <param name="inventory">The initialized inventory of the player</param>
        /// <param name="location">The location of the player</param>
        public Player(int lives, List<Wearable> inventory,
            IEntityLocation location) : base(lives, location)
        {
            _inventory = inventory;
        }

        /// <summary>
        /// Checks whether the player has won based on the amount of sankara stones
        /// </summary>
        public bool Won => Inventory.Count(wearable => wearable is ISankaraStone) >= 5;

        ///<inheritdoc/>
        public IEnumerable<Wearable> Inventory => _inventory;

        ///<inheritdoc/>
        public IEnumerable<Cheat> EnabledCheats => _enabledCheats;

        ///<inheritdoc/>
        public override void ReceiveDamage(int damage)
        {
            if (IsCheatEnabled(Cheat.Invincible))
                return;

            base.ReceiveDamage(damage);
        }

        ///<inheritdoc/>
        public void AddToInventory(Wearable wearable)
        {
            _inventory.Add(wearable);
            NotifyObservers(this);
        }

        ///<inheritdoc/>
        public void ToggleCheat(Cheat cheat)
        {
            if (_enabledCheats.Contains(cheat))
                _enabledCheats.Remove(cheat);
            else
                _enabledCheats.Add(cheat);
        }

        ///<inheritdoc/>
        public bool IsCheatEnabled(Cheat cheat)
        {
            return EnabledCheats.Contains(cheat);
        }

        ///<inheritdoc/>
        public void Shoot()
        {
            var enemies = Location.Room.GetEnemiesWithinReach(Location);

            // Enemies is converted to a list as the original collection might change when enemies die
            enemies.ToList().ForEach(enemy => enemy.ReceiveDamage(1));
        }
    }
}
