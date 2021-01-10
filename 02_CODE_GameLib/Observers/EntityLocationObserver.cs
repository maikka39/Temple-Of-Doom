using System;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib.Observers
{
    public class EntityLocationObserver : BaseObserver<IEntityLocation>, IObserver<IEntityLocation>
    {
        private readonly IGame _game;

        public EntityLocationObserver(IGame game, IEntityLocation entityLocation)
        {
            _game = game;
            entityLocation.Subscribe(this);
        }

        public new void OnNext(IEntityLocation entityLocation)
        {
            _game.Player.Location.Room.Check(_game.Player);
            _game.Update();
        }
    }
}
