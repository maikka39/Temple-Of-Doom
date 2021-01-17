using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces.Tiles
{
    public interface ITile : IRoomObject
    {
        public bool OnEnter(IEntity entity);
    }
}
