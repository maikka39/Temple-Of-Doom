using System.Collections.Generic;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib
{
    public class Player : IPlayer
    {
        public int X { get; }
        public int Y { get; }
        public Room Room { get; set; }
        public int Lives { get; set; }
        public IEnumerable<IKey> Keys { get; set; }
        public IEnumerable<ISankaraStone> SankaraStones { get; set; }

        public Player(int lives, IEnumerable<IKey> keys, IEnumerable<ISankaraStone> sankaraStones)
        {
            Lives = lives;
            Keys = keys;
            SankaraStones = sankaraStones;
        }
    }
}