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

        public Player(int lives, IEnumerable<IKey> keys, IEnumerable<ISankaraStone> sankaraStones, IPlayerLocation location)
        {
            Lives = lives;
            Keys = keys;
            SankaraStones = sankaraStones;
            Location = location;
        }

        public void MovePlayer(Direction direction)
        {
            var target = Location;

            switch (direction)
            {
                case Direction.Top:
                    target.X++;
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

            if (target.X < 0 || target.Y < 0 || target.X > Location.Room.Width || target.Y > Location.Room.Height)
            {
                if (target.Y != (Location.Room.Height + 1) / 2 || target.X != (Location.Room.Width + 1) / 2) return;
                
                var connection = Location.Room.Connections.FirstOrDefault(connections => connections.Direction == direction);
                if (connection == null) return;
                if (!connection.Door.PassThru(this)) return;

                Location.Room = connection.Destination;
                
                if (connection.Direction == Direction.Top || connection.Direction == Direction.Bottom)
                {
                    Location.Y = (Location.Room.Width + 1) / 2;
                    Location.X = connection.Direction == Direction.Top ? Location.Room.Height : 0;
                }
                else
                {
                    Location.X = (Location.Room.Height + 1) / 2;
                    Location.Y = connection.Direction == Direction.Left ? Location.Room.Width : 0;
                }
            }
            Location = target;
        }
    }
}