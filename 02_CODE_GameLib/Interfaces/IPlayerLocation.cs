using CODE_GameLib.Enums;

namespace CODE_GameLib.Interfaces
{
    public interface IPlayerLocation : IBaseObservable<IPlayerLocation>
    {
        public IRoom Room { get; }
        public int X { get; }
        public int Y { get; }
        public Direction? LastDirection { get; }

        public bool Update(IRoom room, int x, int y, Direction? direction = null);
    }
}
