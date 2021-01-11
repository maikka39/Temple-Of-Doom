using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Observers
{
    public class EntityDiedObserver : BaseObserver<IEntity>
    {
        private readonly IRoom _room;

        public EntityDiedObserver(IRoom room)
        {
            _room = room;
        }

        public override void OnNext(IEntity entity)
        {
            if (!entity.Died) return;

            if (entity is IEnemy enemy)
                _room.RemoveEnemy(enemy);
        }
    }
}
