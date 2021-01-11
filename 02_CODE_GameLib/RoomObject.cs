using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public abstract class RoomObject : IRoomObject
    {
        protected RoomObject(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual int X { get; }
        public virtual int Y { get; }
    }
}
