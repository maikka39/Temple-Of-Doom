using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    public class EntityLocation : BaseObservable<IEntityLocation>, IEntityLocation
    {
        public EntityLocation(IRoom room, int x, int y)
        {
            Room = room;
            X = x;
            Y = y;
        }

        public IRoom Room { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public Direction? LastDirection { get; private set; }

        public void Update(IRoom room, int x, int y, Direction? direction = null)
        {
            if (!room.IsWithinBoundaries(x, y))
                return;

            Room = room;
            X = x;
            Y = y;
            LastDirection = direction;

            NotifyObservers(this);
        }
    }
}
