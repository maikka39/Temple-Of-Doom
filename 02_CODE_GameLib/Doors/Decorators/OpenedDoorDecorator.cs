using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors.Decorators
{
    public sealed class OpenedDoorDecorator : BaseDoorDecorator
    {
        public OpenedDoorDecorator(IDoor decoratee) : base(decoratee)
        {
            Opened = true;
        }
    }
}
