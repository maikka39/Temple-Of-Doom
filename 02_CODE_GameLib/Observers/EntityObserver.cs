using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Observers
{
    public class EntityObserver : BaseObserver<IEntity>, IObserver<IEntity>
    {
        private readonly IGame _game;

        public EntityObserver(IGame game, IEntity entity)
        {
            _game = game;
            entity.Subscribe(this);
        }

        public new void OnNext(IEntity entity)
        {
            if (entity is IPlayer player)
            {
                if (player.Died || player.Won)
                    _game.Destroy();
            }

            if (entity.Died)
            {
                // TODO: Remove entity
            }
        }
    }
}
