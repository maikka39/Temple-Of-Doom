using System.Collections.Generic;
using CODE_GameLib.Enums;

namespace CODE_GameLib
{
    /// <summary>
    /// Specifies the data send from the client to the game
    /// </summary>
    public class TickData
    {
        /// <summary>
        /// Specifies if and in what direction the player should be moved
        /// </summary>
        public Direction? MovePlayer { get; set; }
        
        /// <summary>
        /// A collection which hold the cheats that should be toggled for the player
        /// </summary>
        public IEnumerable<Cheat> ToggleCheats { get; set; }
        
        /// <summary>
        /// Specifies whether the game should quit
        /// </summary>
        public bool Quit { get; set; }
        
        /// <summary>
        /// Specifies whether the player should shoot at an enemy
        /// </summary>
        public bool Shoot { get; set; }
    }
}
