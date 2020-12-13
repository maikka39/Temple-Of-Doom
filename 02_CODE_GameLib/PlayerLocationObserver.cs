using System;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class PlayerLocationObserver : IObserver<IPlayerLocation>
    {
        private readonly IGame _game;

        public PlayerLocationObserver(IGame game, IPlayerLocation playerLocation)
        {
            _game = game;
            playerLocation.Subscribe(this);
        }
        
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IPlayerLocation value)
        {
            _game.Update();
        }
    }
}