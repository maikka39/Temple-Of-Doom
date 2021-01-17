using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib
{
    public class Connection : IConnection
    {
        public Connection(IRoom room, Direction direction, int x, int y, IDoor door = null)
        {
            Room = room;
            Direction = direction;
            X = x;
            Y = y;
            Door = door;
        }

        ///<inheritdoc/>
        public IRoom Room { get; }
        
        ///<inheritdoc/>
        public IConnection Destination { get; set; }
        
        ///<inheritdoc/>
        public Direction Direction { get; }
        
        ///<inheritdoc/>
        public IDoor Door { get; }
        
        ///<inheritdoc/>
        public int X { get; }
        
        ///<inheritdoc/>
        public int Y { get; }

        ///<inheritdoc/>
        public bool TryEnter(IEntity entity, int targetX, int targetY)
        {
            if (targetX != X || targetY != Y) return false;

            if (!Door?.CanEnter(entity) ?? false)
                return false;

            Enter(entity);
            return true;
        }

        /// <summary>
        /// Move an entity to the destination of the connection
        /// </summary>
        /// <param name="entity">The entity to move</param>
        private void Enter(IEntity entity)
        {
            var (targetX, targetY) = GetTargetLocation();
            entity.Location.Update(Destination.Room, targetX, targetY, Direction);
        }

        /// <summary>
        /// Gets the target location of
        /// </summary>
        /// <returns>The x and y location</returns>
        private (int x, int y) GetTargetLocation()
        {
            var targetX = Destination.X;
            var targetY = Destination.Y;

            if (Direction.IsVertical())
                targetY += Direction == Direction.North ? 1 : -1;
            else if (Direction.IsHorizontal())
                targetX += Direction == Direction.East ? 1 : -1;
            
            return (targetX, targetY);
        }
    }
}
