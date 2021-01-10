using System;

namespace CODE_GameLib.Interfaces
{
    public interface IGame
    {
        public event EventHandler<Game> Updated;
        public void Update();
        public bool Quit { get; }
        public IPlayer Player { get; }
        public void Tick(TickData tickData);
        public void Destroy();
    }
}
