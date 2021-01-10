using System.Collections.Generic;
using CODE_GameLib.Enums;

namespace CODE_GameLib
{
    public class TickData
    {
        public Direction? MovePlayer { get; set; }
        public IEnumerable<Cheat> ToggleCheats { get; set; }
        public bool Quit { get; set; }
        public bool Shoot { get; set; }
    }
}
