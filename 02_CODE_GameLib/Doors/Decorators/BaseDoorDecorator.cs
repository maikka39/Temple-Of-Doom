using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Doors.Decorators
{
    public abstract class BaseDoorDecorator : IDoor
    {
        private IDoor _decoratee { get; }

        public BaseDoorDecorator(IDoor decoratee)
        {
            _decoratee = decoratee;
        }

        public virtual bool Opened
        {
            get => _decoratee.Opened;
            set => _decoratee.Opened = value;
        }

        public virtual bool CanEnter(IEntity entity) => _decoratee.CanEnter(entity);
    }
}
