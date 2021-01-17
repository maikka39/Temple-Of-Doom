namespace CODE_GameLib.Interfaces.Entity
{
    /// <summary>
    /// An enemy in the game, deals damage
    /// </summary>
    public interface IEnemy : IEntity
    {
        /// <summary>
        /// Notifies the enemy that it should update and move along it's path
        /// </summary>
        public void Update();
        
        /// <summary>
        /// Tells the enemy a player is standing on it
        /// </summary>
        /// <param name="player">The player standing on the enemy</param>
        public void OnEnter(IPlayer player);
    }
}
