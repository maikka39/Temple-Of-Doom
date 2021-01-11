using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Observers
{
    public class EntityLocationObserver : BaseObserver<IEntityLocation>
    {
        private readonly IEntity _entity;

        public EntityLocationObserver(IEntity entity)
        {
            _entity = entity;
        }

        public override void OnNext(IEntityLocation entityLocation)
        {
            _entity.Location.Room.Check(_entity);
        }
    }
}
