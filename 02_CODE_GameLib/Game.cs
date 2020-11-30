using System;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class Game : IGame
    {
        public event EventHandler<Game> Updated;

        public ConsoleKey KeyPressed { get; private set; }
        public bool Quit { get; private set; }
        
        public PlayerLocation PlayerLocation { get; private set; }

        public void Run()
        {
            KeyPressed = Console.ReadKey().Key;
            Quit = KeyPressed == ConsoleKey.Escape;

            while (!Quit)
            {
                Updated?.Invoke(this, this);

                KeyPressed = Console.ReadKey().Key;
                Quit = KeyPressed == ConsoleKey.Escape;
            }

            Updated?.Invoke(this, this);
        }
    }
}
