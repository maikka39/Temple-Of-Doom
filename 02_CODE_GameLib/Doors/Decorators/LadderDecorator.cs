using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors.Decorators
{
    /// <summary>
    /// Implements a ladder
    /// </summary>
    public class LadderDecorator : BaseDoorDecorator, ILadder
    {
        ///<inheritdoc/>
        public LadderDecorator(IDoor decoratee) : base(decoratee)
        {
        }
    }
}
