using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors
{
    public class ClosingDoor : Door, IClosingDoor
    {
        public ClosingDoor() : base(true)
        {
        }

        public override bool CanEnter(IEntity entity)
        {
            var canEnter = base.CanEnter(entity);
            Opened = false;
            return canEnter;
        }
    }
}
