using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Tiles;

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
            TryEnterRoomTile(playerLocation);
            TryEnterRoomItem(playerLocation);

            _game.Update();
        }

        private void TryEnterRoomItem(IPlayerLocation playerLocation)
        {
            var roomItem = playerLocation.Room.GetItem(playerLocation.X, playerLocation.Y);
            roomItem?.OnEnter(_game.Player);
        }

        private void TryEnterRoomTile(IPlayerLocation playerLocation)
        {
            var roomTile = playerLocation.Room.GetTile(playerLocation.X, playerLocation.Y);
            roomTile?.OnEnter(_game.Player, playerLocation.LastDirection);
        }
    }
}
