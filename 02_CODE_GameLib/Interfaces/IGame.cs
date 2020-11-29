using System;

namespace CODE_GameLib.Interfaces
{
    public interface IGame
    {
        public event EventHandler<Game> Updated;

        public ConsoleKey KeyPressed { get; }
        public bool Quit { get; }

        public void Run();
    }
}