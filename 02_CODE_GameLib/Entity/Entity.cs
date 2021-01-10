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
        public IEntityLocation Location { get; protected set; }
        public int Lives { get; protected set; }
        public bool Died => Lives < 1;
        
        public bool Move(Direction direction)
        {
            var (targetX, targetY) = DirectionToXy(direction);

            if (Location.Room.Connections.Any(connection => connection.TryEnter(this, targetX, targetY)))
                return true;

            if (!Location.Room.IsWithinBoundaries(targetX, targetY)) return false;
            
            Location.Update(Location.Room, targetX, targetY, direction);
            
            return true;

        }

        public void ReceiveDamage(int damage)
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
