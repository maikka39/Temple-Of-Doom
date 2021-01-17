using System;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces
{
    /// <summary>
    /// The general game which hold everything together
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Specifies whether the game has quit
        /// </summary>
        public bool Quit { get; }
        
        /// <summary>
        /// Specifies the player who plays the game
        /// </summary>
        public IPlayer Player { get; }
        
        /// <summary>
        /// Holds game subscribers
        /// </summary>
        public event EventHandler<Game> Updated;
        
        /// <summary>
        /// Sends a message to all subscribers that the game updated 
        /// </summary>
        public void Update();
        
        /// <summary>
        /// Handles user input
        /// </summary>
        /// <param name="tickData">A tick with new information</param>
        public void Tick(TickData tickData);
        
        /// <summary>
        /// Safely exits the game
        /// </summary>
        public void Destroy();
    }
}
