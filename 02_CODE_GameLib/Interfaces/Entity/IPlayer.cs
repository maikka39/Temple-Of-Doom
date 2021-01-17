using System.Collections.Generic;
using CODE_GameLib.Enums;
using CODE_GameLib.Items.Wearable;

namespace CODE_GameLib.Interfaces.Entity
{
    /// <summary>
    /// The player of the game
    /// </summary>
    public interface IPlayer : IEntity
    {
        /// <summary>
        /// Specifies whether the player has won
        /// </summary>
        public bool Won { get; }
        
        /// <summary>
        /// Holds the player inventory
        /// </summary>
        public IEnumerable<Wearable> Inventory { get; }
        
        /// <summary>
        /// Holds all cheats which are enabled
        /// </summary>
        public IEnumerable<Cheat> EnabledCheats { get; }
        
        /// <summary>
        /// Add a wearable item to the player inventory
        /// </summary>
        /// <param name="wearable">The wearable item which to wear</param>
        public void AddToInventory(Wearable wearable);
        
        /// <summary>
        /// Toggle a cheats from the Enabled cheats
        /// </summary>
        /// <param name="cheat">The cheat to toggke</param>
        public void ToggleCheat(Cheat cheat);
        
        /// <summary>
        /// Checks whether a cheat is enabled of not
        /// </summary>
        /// <param name="cheat">The cheat to check for</param>
        /// <returns>Whether the cheat is enabled</returns>
        public bool IsCheatEnabled(Cheat cheat);
        
        /// <summary>
        /// Tells the player to shoot
        /// </summary>
        public void Shoot();
    }
}
