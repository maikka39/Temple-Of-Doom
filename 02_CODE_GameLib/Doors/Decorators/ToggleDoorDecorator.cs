using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors.Decorators
{
    public class ToggleDoorDecorator : BaseDoorDecorator, IToggleDoor
    {
        public ToggleDoorDecorator(IDoor decoratee) : base(decoratee)
        {
        }
    }
}
