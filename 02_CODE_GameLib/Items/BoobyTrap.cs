using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items.BoobyTraps;

namespace CODE_GameLib.Items
{
    /// <summary>
    /// Implements a booby trap item, deals damage
    /// </summary>
    public class BoobyTrap : Item, IBoobyTrap
    {
        private readonly int _damage;
        
        /// <summary>
        /// Creates a new instance based on the passed parameters
        /// </summary>
        /// <param name="x">The x coordinate of the trap</param>
        /// <param name="y">The y coordinate of the trap</param>
        /// <param name="damage">The amount of damage the trap deals</param>
        public BoobyTrap(ILocation location, int damage) : base(location)
        {
            _damage = damage;
        }

        /// <summary>
        /// Deals damage to the player
        /// </summary>
        /// <param name="player">The player standing on the trap</param>
        public override void OnEnter(IPlayer player)
        {
            player.ReceiveDamage(_damage);
        }
    }
}
