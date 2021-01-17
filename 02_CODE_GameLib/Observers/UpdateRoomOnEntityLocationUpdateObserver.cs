using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Observers
{
    public class UpdateRoomOnEntityLocationUpdateObserver : EntityLocationObserver
    {
        private IGame _game;

        public UpdateRoomOnEntityLocationUpdateObserver(IGame game, IEntity entity) : base(entity)
        {
            _game = game;
        }

        public override void OnNext(IEntityLocation entityLocation)
        {
            _game.Update();
            base.OnNext(entityLocation);
        }
    }
}
