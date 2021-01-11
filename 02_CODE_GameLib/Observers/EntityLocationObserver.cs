using System;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib.Observers
{
    public class EntityLocationObserver : BaseObserver<IEntityLocation>, IObserver<IEntityLocation>
    {
        private readonly IGame _game;

        public EntityLocationObserver(IGame game)
        {
            _game = game;
        }

        public new void OnNext(IEntityLocation entityLocation)
        {
            _game.Player.Location.Room.Check(_game.Player);
            _game.Update();
        }
    }
}
