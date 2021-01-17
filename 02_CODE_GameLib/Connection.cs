﻿using CODE_GameLib.Enums;
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

        public IRoom Room { get; }
        public IConnection Destination { get; set; }
        public Direction Direction { get; }
        public IDoor Door { get; }
        public int X { get; }
        public int Y { get; }

        public bool TryEnter(IEntity entity, int entityX, int entityY)
        {
            if (entityX != X || entityY != Y) return false;

            if (!Door?.CanEnter(entity) ?? false)
                return false;

            Enter(entity);
            return true;
        }

        private void Enter(IEntity entity)
        {
            var (targetX, targetY) = GetTargetLocation();
            entity.Location.Update(Destination.Room, targetX, targetY, Direction);
        }

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
