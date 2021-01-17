using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Observers
{
    /// <summary>
    /// An observer that runs the room.check method when the specified entity has moved
    /// </summary>
    public class UpdateRoomEntityLocationObserver : BaseObserver<IEntityLocation>
    {
        private readonly IEntity _entity;

        public UpdateRoomEntityLocationObserver(IEntity entity)
        {
            _entity = entity;
        }
        
        /// <summary>
        /// Calls the room.check method
        /// </summary>
        /// <param name="entityLocation">The new entity location</param>
        public override void OnNext(IEntityLocation entityLocation)
        {
            _entity.Location.Room.Check(_entity);
        }
    }
}
