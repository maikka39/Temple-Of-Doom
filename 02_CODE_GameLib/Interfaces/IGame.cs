using System;
using CODE_GameLib.Interfaces.Entity;

namespace CODE_GameLib.Interfaces
{
    public interface IGame
    {
        public bool Quit { get; }
        public IPlayer Player { get; }
        public event EventHandler<Game> Updated;
        public void Update();
        public void Tick(TickData tickData);
        public void Destroy();
    }
}
