using System;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib.Observers
{
    public class PlayerObserver : BaseObserver<IPlayer>, IObserver<IPlayer>
    {
        private readonly IGame _game;

        public PlayerObserver(IGame game, IPlayer player)
        {
            _game = game;
            player.Subscribe(this);
        }
        
        public new void OnNext(IPlayer player)
        {
            if (player.Died || player.Won)
                _game.Destroy();
        }
    }
}
