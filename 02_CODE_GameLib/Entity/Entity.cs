using System;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Observers;

namespace CODE_GameLib.Entity
{
    /// <summary>
    /// Implements a base class for an entity
    /// </summary>
    public abstract class Entity : BaseObservable<IEntity>, IEntity
    {
        private int _lives;

        /// <summary>
        /// Creates a new instance from the provided parameters
        /// </summary>
        /// <param name="lives">The amount of lives</param>
        /// <param name="location">The starting location</param>
        protected Entity(int lives, IEntityLocation location)
        {
            _lives = lives;
            Location = location;
        }

        /// <summary>
        /// For classes that extend this entity and overwrite the amount of lives and the location
        /// </summary>
        protected Entity()
        {
        }

        ///<inheritdoc/>
        public virtual IEntityLocation Location { get; }

        ///<inheritdoc/>
        public virtual int Lives
        {
            get => _lives;
            protected set => _lives = value;
        }

        ///<inheritdoc/>
        public virtual bool Died => Lives < 1;

        ///<inheritdoc/>
        public virtual bool Move(Direction direction)
        {
            var location = DirectionToLocation(direction);

            // Tries to enter every connection in the room
            if (Location.Room.Connections.Any(connection => connection.TryEnter(this, location)))
                return true;

            if (!Location.Room.IsWithinBoundaries(location)) return false;

            Location.Update(Location.Room, location, direction);

            return true;
        }

        ///<inheritdoc/>
        public virtual void ReceiveDamage(int damage)
        {
            if (damage <= 0)
                return;
            Lives -= damage;
            NotifyObservers(this);
        }

        /// <summary>
        /// Converts a direction into x, y coordinates, based on the current location
        /// </summary>
        /// <param name="direction">The direction to convert</param>
        /// <returns>The x and y of the resulting location</returns>
        /// <exception cref="ArgumentOutOfRangeException">The the specified location is invalid, this exeption is thrown</exception>
        private ILocation DirectionToLocation(Direction direction)
        {
            var x = Location.X;
            var y = Location.Y;

            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (direction)
            {
                case Direction.North:
                    y--;
                    break;
                case Direction.East:
                    x++;
                    break;
                case Direction.South:
                    y++;
                    break;
                case Direction.West:
                    x--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction,
                        "There are only four possible directions");
            }

            return new Location(x, y);
        }
    }
}
