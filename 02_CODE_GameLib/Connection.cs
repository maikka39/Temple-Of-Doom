using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib
{
    public class Connection : IConnection
    {
        public IRoom Room { get; }
        public IConnection Destination { get; set; }
        public Direction Direction { get; }
        public IDoor Door { get; }
        public int X { get; }
        public int Y { get; }

        public Connection(IRoom room, Direction direction, IDoor door = null)
        {
            Room = room;
            Direction = direction;
            Door = door;
            
            if (Direction == Direction.North || Direction == Direction.South)
            {
                X = (Room.Width + 1) / 2 - 1;
                Y = Direction == Direction.South ? 0 : Room.Height - 1;
            }
            else
            {
                X = Direction == Direction.West ? 0 : Room.Width - 1;
                Y = (Room.Height + 1) / 2 - 1;
            }
        }

        public bool TryEnter(Player player, int playerX, int playerY)
        {
            if (playerX != X || playerY != Y) return false;

            if (!Door?.CanEnter(player) ?? false)
                return false;

            var targetX = Destination.X;
            var targetY = Destination.Y;
            
            if (Direction == Direction.North || Direction == Direction.South)
                targetY += Direction == Direction.North ? 1 : -1;
            else
                targetX += Direction == Direction.East ? 1 : -1;

            return player.Location.Update(Destination.Room, targetX, targetY);
        }
    }
}
