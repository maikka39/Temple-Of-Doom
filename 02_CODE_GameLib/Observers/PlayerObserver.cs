using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Observers
{
    public class PlayerObserver : BaseObserver<IPlayer>, IObserver<IEntity>
    {
        private readonly IGame _game;

        public PlayerObserver(IGame game)
        {
            _game = game;
        }

        public override void OnNext(IPlayer player) => OnNextPlayer(player);
        public void OnNext(IEntity entity)
        {
            if (!(entity is IPlayer player))
                throw new ArgumentException("PlayerObserver only works for players.");

            OnNextPlayer(player);
        }

        private void OnNextPlayer(IPlayer player)
        {
            if (player.Died || player.Won)
                _game.Destroy();
        }
    }
}
