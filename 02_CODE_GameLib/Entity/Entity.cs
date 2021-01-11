using System;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Observers;

namespace CODE_GameLib.Entity
{
    public abstract class Entity : BaseObservable<IEntity>, IEntity
    {
        private int _lives;
        private IEntityLocation _location;

        public virtual IEntityLocation Location
        {
            get => _location;
            protected set => _location = value;
        }

        public virtual int Lives
        {
            get => _lives;
            protected set => _lives = value;
        }

        public virtual bool Died => Lives < 1;

        protected Entity(int lives, IEntityLocation location)
        {
            _lives = lives;
            _location = location;
        }

        protected Entity()
        {
        }

        public virtual bool Move(Direction direction)
        {
            var (targetX, targetY) = DirectionToXy(direction);

            if (Location.Room.Connections.Any(connection => connection.TryEnter(this, targetX, targetY)))
                return true;

            if (!Location.Room.IsWithinBoundaries(targetX, targetY)) return false;

            Location.Update(Location.Room, targetX, targetY, direction);

            return true;
        }

        public virtual void ReceiveDamage(int damage)
        {
            if (damage <= 0)
                return;
            Lives -= damage;
            NotifyObservers(this);
        }

        private (int, int) DirectionToXy(Direction direction)
        {
            var targetX = Location.X;
            var targetY = Location.Y;

            switch (direction)
            {
                case Direction.North:
                    targetY++;
                    break;
                case Direction.East:
                    targetX++;
                    break;
                case Direction.South:
                    targetY--;
                    break;
                case Direction.West:
                    targetX--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction,
                        "There are only four directions");
            }

            return (targetX, targetY);
        }
    }
}
