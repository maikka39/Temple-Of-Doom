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

        public int X => Direction.IsVertical()
            ? Room.CenterX
            : Direction == Direction.West ? 0 : Room.Width - 1;

        public int Y => Direction.IsHorizontal()
            ? Room.CenterY
            : Direction == Direction.South ? 0 : Room.Height - 1;

        public Connection(IRoom room, Direction direction, IDoor door = null)
        {
            Room = room;
            Direction = direction;
            Door = door;
        }

        public bool TryEnter(IPlayer player, int playerX, int playerY)
        {
            if (playerX != X || playerY != Y) return false;

            if (!Door?.CanEnter(player) ?? false)
                return false;

            Enter(player);
            return true;
        }

        private void Enter(IPlayer player)
        {
            var targetX = Destination.X;
            var targetY = Destination.Y;

            if (Direction.IsVertical())
                targetY += Direction == Direction.North ? 1 : -1;
            else
                targetX += Direction == Direction.East ? 1 : -1;

            player.Location.Update(Destination.Room, targetX, targetY);
        }
    }
}
