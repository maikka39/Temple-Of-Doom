using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib
{
    public class Player : IPlayer
    {
        public IPlayerLocation Location { get; private set; }
        public int Lives { get; set; }
        public IEnumerable<IKey> Keys { get; set; }
        public IEnumerable<ISankaraStone> SankaraStones { get; set; }

        public Player(int lives, IEnumerable<IKey> keys, IEnumerable<ISankaraStone> sankaraStones,
            IPlayerLocation location)
        {
            Lives = lives;
            Keys = keys;
            SankaraStones = sankaraStones;
            Location = location;
        }

        public bool Move(Direction direction)
        {
            var target = new PlayerLocation(Location.Room, Location.X, Location.Y);

            switch (direction)
            {
                case Direction.Top:
                    target.Y++;
                    break;
                case Direction.Right:
                    target.X++;
                    break;
                case Direction.Bottom:
                    target.Y--;
                    break;
                case Direction.Left:
                    target.X--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction,
                        "There are only four directions");
            }

            if (target.X < 0 || target.Y < 0 || target.X > target.Room.Width - 1 || target.Y > target.Room.Height - 1)
            {
                var isCenterX = target.X == (target.Room.Width + 1) / 2 - 1;
                var isCenterY = target.Y == (target.Room.Height + 1) / 2 - 1;

                if (!isCenterX && !isCenterY)
                    return false;

                var connection = target.Room.Connections.FirstOrDefault(
                    connections => connections.Direction == direction);

                if (connection == null) return false;

                if (connection.Door != null && !connection.Door.PassThru(this))
                    return false;

                var destination = connection.Destination;
                target.Room = destination.Room;

                if (destination.Direction == Direction.Top || destination.Direction == Direction.Bottom)
                {
                    target.X = (target.Room.Width + 1) / 2 - 1;
                    target.Y = destination.Direction == Direction.Top ? target.Room.Height - 1 : 0;
                }
                else
                {
                    target.X = destination.Direction == Direction.Left ? 0 : target.Room.Width - 1;
                    target.Y = (target.Room.Height + 1) / 2 - 1;
                }
            }

            Location = target;
            return true;
        }
    }
}
