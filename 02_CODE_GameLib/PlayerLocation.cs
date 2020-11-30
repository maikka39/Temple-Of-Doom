using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class PlayerLocation : IPlayerLocation
    {
        public Room Room { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public PlayerLocation(Room room, int x, int y)
        {
            Room = room;
            X = x;
            Y = y;
        }
    }
}
