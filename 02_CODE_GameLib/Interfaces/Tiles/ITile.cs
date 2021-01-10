using CODE_GameLib.Enums;

namespace CODE_GameLib.Interfaces.Tiles
{
    public interface ITile : IRoomObject
    {
        public void OnEnter(IPlayer player, Direction? direction);
    }
}
