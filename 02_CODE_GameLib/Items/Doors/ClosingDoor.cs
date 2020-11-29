using CODE_GameLib.Interfaces.Items.Doors;

namespace CODE_GameLib.Items.Doors
{
    public class ClosingDoor : IClosingDoor
    {
        public int X { get; }
        public int Y { get; }
        public bool Opened { get; set; }

        public ClosingDoor(int x, int y)
        {
            X = x;
            Y = y;
            Opened = true;
        }
    }
}