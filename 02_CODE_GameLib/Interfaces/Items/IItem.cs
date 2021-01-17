using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces.Items
{
    /// <summary>
    /// A general item in a room
    /// </summary>
    public interface IItem : IRoomObject
    {
        /// <summary>
        /// Tells the item a player is standing on it
        /// </summary>
        /// <param name="player">The player standing on the tile</param>
        public void OnEnter(IPlayer player);
    }
}
