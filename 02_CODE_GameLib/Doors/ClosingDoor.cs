using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors
{
    public class ClosingDoor : Door, IClosingDoor
    {
        public ClosingDoor()
        {
            Opened = true;
        }

        public new bool CanEnter(IEntity entity)
        {
            var canEnter = base.CanEnter(entity);
            Opened = false;
            return canEnter;
        }
    }
}
