using System;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib.Observers
{
    public class PlayerLocationObserver : BaseObserver<IPlayerLocation>, IObserver<IPlayerLocation>
    {
        private readonly IGame _game;

        public PlayerLocationObserver(IGame game, IPlayerLocation playerLocation)
        {
            _game = game;
            playerLocation.Subscribe(this);
        }

        public new void OnNext(IPlayerLocation playerLocation)
        {
            var roomItem = playerLocation.Room.GetItem(playerLocation.X, playerLocation.Y);
            roomItem?.OnEnter(_game.Player);
            
            _game.Update();
        }
    }
}
