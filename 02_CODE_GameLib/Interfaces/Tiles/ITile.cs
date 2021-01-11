using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces.Tiles
{
    public interface ITile : IRoomObject
    {
        public void OnEnter(IEntity entity);
    }
}
