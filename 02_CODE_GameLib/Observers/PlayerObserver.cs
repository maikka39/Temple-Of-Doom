using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Observers
{
    public class PlayerObserver : BaseObserver<IPlayer>, IObserver<IPlayer>, IObserver<IEntity>
    {
        private readonly IGame _game;

        public PlayerObserver(IGame game)
        {
            _game = game;
        }

        public new void OnNext(IPlayer player)
        {
            if (player.Died || player.Won)
                _game.Destroy();
        }

        public void OnNext(IEntity entity) => OnNext(entity as IPlayer);
    }
}
