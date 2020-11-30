using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class PlayerLocation : IPlayerLocation
    {
        public IRoom Room { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public PlayerLocation(IRoom room, int x, int y)
        {
            Room = room;
            X = x;
            Y = y;
        }
    }
}
