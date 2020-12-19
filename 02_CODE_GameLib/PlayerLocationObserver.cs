using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.BoobyTraps;
using CODE_GameLib.Interfaces.Items.Wearable;
using System;
using System.Linq;
using CODE_GameLib.Items;

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

        public void OnNext(IPlayerLocation playerLocation)
        {
            var roomItem = playerLocation.Room.GetItem(playerLocation.X, playerLocation.Y);
            roomItem?.OnEnter(_game.Player);
            
            _game.Update();
        }
    }
}
