using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors.Decorators
{
    public class ClosingDoorDecorator : BaseDoorDecorator, IClosingDoor
    {
        public ClosingDoorDecorator(IDoor decoratee) : base(decoratee)
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
