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

        public bool ReceiveDamage(int damage)
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

            if (Location.Room.IsWithinBoundaries(targetX, targetY))
                return Location.Update(Location.Room, targetX, targetY);

            foreach (var connection in Location.Room.Connections)
                if (connection.TryEnter(this, targetX, targetY))
                    return true;

            return false;
        }
    }
}
