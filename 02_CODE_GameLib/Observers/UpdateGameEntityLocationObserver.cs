using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Observers
{
    /// <summary>
    /// An observer that updates the game when the base has been updated
    /// </summary>
    public class UpdateGameEntityLocationObserver : UpdateRoomEntityLocationObserver
    {
        private readonly IGame _game;

        public UpdateGameEntityLocationObserver(IGame game, IEntity entity) : base(entity)
        {
            _game = game;
        }

        ///<inheritdoc/>
        public override void OnNext(IEntityLocation entityLocation)
        {
            _game.Update();
            base.OnNext(entityLocation);
        }
    }
}
