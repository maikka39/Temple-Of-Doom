using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors.Decorators
{
    /// <summary>
    /// Implements a door that closes after an entity has passed through it
    /// </summary>
    public class ClosingDoorDecorator : BaseDoorDecorator, IClosingDoor
    {
        private bool _forcedClosed = false;
        
        ///<inheritdoc/>
        public ClosingDoorDecorator(IDoor decoratee) : base(decoratee)
        {
        }

        /// <summary>
        /// Checks the base class to check if the user can enter the room
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override bool CanEnter(IEntity entity)
        {
            var canEnter = !_forcedClosed && base.CanEnter(entity);
            if (canEnter)
                _forcedClosed = true;
            return canEnter;
        }
    }
}
