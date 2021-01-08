using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors
{
    public class Ladder: Door, ILadder
    {
        public Ladder()
        {
            Opened = true;
        }
    }
}
