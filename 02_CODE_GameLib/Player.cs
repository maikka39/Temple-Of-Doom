using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.Wearable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CODE_GameLib
{
    public class Player : BaseObservable<IPlayer>, IPlayer
    {
        private readonly List<IWearable> _inventory;
        public IPlayerLocation Location { get; }
        public int Lives { get; private set; }

        public bool Died => Lives < 1;

        public bool Won => Inventory.Count(wearable => wearable is ISankaraStone) >= 5;

        public IEnumerable<IWearable> Inventory => _inventory;

        public Player(int lives, List<IWearable> inventory,
            IPlayerLocation location)
        {
            Lives = lives;
            _inventory = inventory;
            Location = location;
        }

        public bool RecieveDamage(int damage)
        {
            if (damage <= 0)
                return false;
            Lives -= damage;
            NotifyObservers(this);
            return true;
        }

        public bool AddToInventory(IWearable wearable)
        {
            _inventory.Add(wearable);
            NotifyObservers(this);
            return true;
        }

        public bool Move(Direction direction)
        {
            var targetX = Location.X;
            var targetY = Location.Y;
            var targetRoom = Location.Room;

            switch (direction)
            {
                case Direction.Top:
                    targetY++;
                    break;
                case Direction.Right:
                    targetX++;
                    break;
                case Direction.Bottom:
                    targetY--;
                    break;
                case Direction.Left:
                    targetX--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction,
                        "There are only four directions");
            }

            if (targetX < 0 || targetY < 0 || targetX > targetRoom.Width - 1 || targetY > targetRoom.Height - 1)
            {
                var isCenterX = targetX == (targetRoom.Width + 1) / 2 - 1;
                var isCenterY = targetY == (targetRoom.Height + 1) / 2 - 1;

                if (!isCenterX && !isCenterY)
                    return false;

                var connection = targetRoom.Connections.FirstOrDefault(
                    connections => connections.Direction == direction);

                if (connection == null) return false;

                if (connection.Door != null && !connection.Door.PassThru(this))
                    return false;

                var destination = connection.Destination;
                targetRoom = destination.Room;

                if (destination.Direction == Direction.Top || destination.Direction == Direction.Bottom)
                {
                    targetX = (targetRoom.Width + 1) / 2 - 1;
                    targetY = destination.Direction == Direction.Top ? targetRoom.Height - 1 : 0;
                }
                else
                {
                    targetX = destination.Direction == Direction.Left ? 0 : targetRoom.Width - 1;
                    targetY = (targetRoom.Height + 1) / 2 - 1;
                }
            }

            Location.Update(targetRoom, targetX, targetY);
            return true;
        }
    }
}
