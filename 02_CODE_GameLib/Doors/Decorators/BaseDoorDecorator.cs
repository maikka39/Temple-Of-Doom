using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors.Decorators
{
    /// <summary>
    /// A base door decorator, get the necessary methods from the decoratee.
    /// </summary>
    public abstract class BaseDoorDecorator : IDoor
    {
        private readonly IDoor _decoratee;

        /// <summary>
        /// Create a new instance from a door
        /// </summary>
        /// <param name="decoratee">The door to use</param>
        protected BaseDoorDecorator(IDoor decoratee)
        {
            _decoratee = decoratee;
        }

        ///<inheritdoc/>
        public virtual bool Opened
        {
            get => _decoratee.Opened;
            set => _decoratee.Opened = value;
        }

        ///<inheritdoc/>
        public virtual bool CanEnter(IEntity entity) => _decoratee.CanEnter(entity);
    }
}
