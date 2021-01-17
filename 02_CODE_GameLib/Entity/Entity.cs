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

        protected Entity(int lives, IEntityLocation location)
        {
            _lives = lives;
            Location = location;
        }

        protected Entity()
        {
        }

        public virtual IEntityLocation Location { get; }

        public virtual int Lives
        {
            get => _lives;
            protected set => _lives = value;
        }

        public virtual bool Died => Lives < 1;

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

        private (int x, int y) DirectionToXy(Direction direction)
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

            return (x, y);
        }
    }
}
