using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors.Decorators
{
    /// <summary>
    /// Implements a door which starts opened
    /// </summary>
    public sealed class OpenedDoorDecorator : BaseDoorDecorator
    {
        ///<inheritdoc/>
        public OpenedDoorDecorator(IDoor decoratee) : base(decoratee)
        {
            Opened = true;
        }
    }
}
