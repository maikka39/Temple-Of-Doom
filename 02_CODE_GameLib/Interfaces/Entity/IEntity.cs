using System;
using CODE_GameLib.Enums;

namespace CODE_GameLib.Interfaces.Entity
{
    /// <summary>
    /// An entity in the game
    /// </summary>
    public interface IEntity : IObservable<IEntity>
    {
        /// <summary>
        /// Specifies the location of the entity
        /// </summary>
        public IEntityLocation Location { get; }
        
        /// <summary>
        /// Specifies the amount of lives left
        /// </summary>
        public int Lives { get; }
        
        /// <summary>
        /// Specifies whether the entity has died
        /// </summary>
        public bool Died { get; }

        /// <summary>
        /// Makes the entity receive damage
        /// </summary>
        /// <param name="damage">The amount of damage to receive</param>
        public void ReceiveDamage(int damage);
        
        /// <summary>
        /// Moves the entity in a direction
        /// </summary>
        /// <param name="direction">The direction in which to move</param>
        /// <returns>Whether the entity has moved there</returns>
        public bool Move(Direction direction);
    }
}
