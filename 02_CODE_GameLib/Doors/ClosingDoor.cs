using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors
{
    public class ClosingDoor : Door, IClosingDoor
    {
        public ClosingDoor()
        {
            Opened = true;
        }

        public new bool CanEnter(IPlayer player)
        {
            var canEnter = base.CanEnter(player);
            Opened = false;
            return canEnter;
        }
    }
}
