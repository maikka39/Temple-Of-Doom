using CODE_GameLib.Interfaces.Items.Doors;

namespace CODE_GameLib.Items.Doors
{
    public class ClosingDoor : IClosingDoor
    {
        public bool Opened { get; set; }

        public ClosingDoor()
        {
            Opened = true;
        }
    }
}
