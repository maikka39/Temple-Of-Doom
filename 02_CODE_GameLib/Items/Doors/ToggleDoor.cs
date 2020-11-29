using CODE_GameLib.Interfaces.Items.Doors;

namespace CODE_GameLib.Items.Doors
{
    public class ToggleDoor : IDoor
    {
        public int X { get; }
        public int Y { get; }
        public bool Opened { get; set; }

        public ToggleDoor(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}