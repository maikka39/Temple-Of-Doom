using CODE_GameLib.Interfaces.Doors;

namespace CODE_GameLib.Doors.Decorators
{
    public class LadderDecorator : BaseDoorDecorator, ILadder
    {
        public LadderDecorator(IDoor decoratee) : base(decoratee)
        {
        }
    }
}
