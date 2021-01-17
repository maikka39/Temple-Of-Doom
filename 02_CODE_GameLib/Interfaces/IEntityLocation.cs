using System;
using CODE_GameLib.Enums;

namespace CODE_GameLib.Interfaces
{
    public interface IEntityLocation : IObservable<IEntityLocation>
    {
        public IRoom Room { get; }
        public int X { get; }
        public int Y { get; }
        public Direction? LastDirection { get; }

        public void Update(IRoom room, int x, int y, Direction? direction = null);
    }
}
