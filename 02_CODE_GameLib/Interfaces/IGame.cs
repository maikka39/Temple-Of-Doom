using System;
using System.Collections.Generic;
using CODE_GameLib.Enums;

namespace CODE_GameLib.Interfaces
{
    public interface IGame
    {
        public event EventHandler<Game> Updated;
        public void Update();
        public bool Quit { get; }
        public IPlayer Player { get; }
        public IEnumerable<Cheat> EnabledCheats { get; }
        public void Tick(TickData tickData);
        public void Destroy();
    }
}
