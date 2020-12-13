using System;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.Wearable;

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
            var roomItem = playerLocation.Room.Items.FirstOrDefault(item =>
                item.X == playerLocation.X && item.Y == playerLocation.Y);
            if (roomItem is IWearable wearable)
            {
                _game.Player.Inventory.Add(wearable);
                playerLocation.Room.Items.Remove(wearable);
            }

            _game.Update();
        }
    }
}