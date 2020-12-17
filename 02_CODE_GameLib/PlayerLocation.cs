using System;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class PlayerLocation : BaseObservable<IPlayerLocation>, IPlayerLocation
    {
        public IRoom Room { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public PlayerLocation(IRoom room, int x, int y)
        {
            Room = room;
            X = x;
            Y = y;
        }

        public bool Update(IRoom room, int x, int y)
        {
            Console.WriteLine(room);
            Console.WriteLine(x);
            Console.WriteLine(y);
            if (!room.IsWithinBoundaries(x, y))
                return false;
            Room = room;
            X = x;
            Y = y;
            NotifyObservers(this);
            return true;
        }
    }
}
