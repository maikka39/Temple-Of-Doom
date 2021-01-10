using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public abstract class RoomObject : IRoomObject
    {
        public int X { get; }
        public int Y { get; }

        protected RoomObject(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
