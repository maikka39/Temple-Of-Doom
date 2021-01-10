using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Tiles;

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
            TryEnterRoomTile(entityLocation);
            TryEnterRoomItem(entityLocation);

            _game.Update();
        }

        private void TryEnterRoomItem(IEntityLocation entityLocation)
        {
            var roomItem = entityLocation.Room.GetItem(entityLocation.X, entityLocation.Y);
            roomItem?.OnEnter(_game.Player);
        }

        private void TryEnterRoomTile(IEntityLocation entityLocation)
        {
            var roomTile = entityLocation.Room.GetTile(entityLocation.X, entityLocation.Y);
            roomTile?.OnEnter(_game.Player, entityLocation.LastDirection);
        }
    }
}
