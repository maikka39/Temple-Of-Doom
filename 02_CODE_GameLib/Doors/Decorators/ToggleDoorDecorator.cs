using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors.Decorators
{
    /// <summary>
    /// Implements a door that can be toggled by pressure plates
    /// </summary>
    public class ToggleDoorDecorator : BaseDoorDecorator, IToggleDoor
    {
        ///<inheritdoc/>
        public ToggleDoorDecorator(IDoor decoratee) : base(decoratee)
        {
        }
    }
}
