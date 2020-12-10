using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib
{
    public class Player : IPlayer
    {
        public int X { get; set; }
        public int Y { get; set; }
        public IRoom Room { get; set; }
        public int Lives { get; set; }
        public IEnumerable<IKey> Keys { get; set; }
        public IEnumerable<ISankaraStone> SankaraStones { get; set; }

        public Player(int lives, IEnumerable<IKey> keys, IEnumerable<ISankaraStone> sankaraStones)
        {
            Lives = lives;
            Keys = keys;
            SankaraStones = sankaraStones;
        }

        public void MovePlayer(Direction direction)
        {
            var targetX = X;
            var targetY = Y;

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

            if (targetX < 0 || targetY < 0 || targetX > Room.Width || targetY > Room.Height)
            {
                if (targetY != (Room.Height + 1) / 2 || targetX != (Room.Width + 1) / 2) return;
                
                var connection = Room.Connections.FirstOrDefault(connections => connections.Direction == direction);
                if (connection == null) return;
                if (!connection.Door.PassThru(this)) return;

                Room = connection.Destination;
                
                if (connection.Direction == Direction.Top || connection.Direction == Direction.Bottom)
                {
                    Y = (Room.Width + 1) / 2;
                    X = connection.Direction == Direction.Top ? Room.Height : 0;
                }
                else
                {
                    X = (Room.Height + 1) / 2;
                    Y = connection.Direction == Direction.Left ? Room.Width : 0;
                }
            }

            X = targetX;
            Y = targetY;
        }
    }
}