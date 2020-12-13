using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Items.Doors
{
    public class ClosingDoor : IClosingDoor
    {
        public bool Opened { get; set; }

        public ClosingDoor()
        {
            Opened = true;
        }

        public bool PassThru(IPlayer player)
        {
            if (!Opened) return false;

            Opened = false;

            return true;
        }
    }
}
