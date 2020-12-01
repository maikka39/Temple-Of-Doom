﻿using System;
using System.Collections.Generic;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class Game : IGame
    {
        public event EventHandler<Game> Updated;

        public ConsoleKey KeyPressed { get; private set; }
        public bool Quit { get; private set; }
        
        public IPlayer Player { get; }
        public IPlayerLocation PlayerLocation { get; private set; }
        public IEnumerable<IRoom> Rooms { get; }

        public Game(IPlayer player, IPlayerLocation playerLocation, IEnumerable<IRoom> rooms)
        {
            Player = player;
            PlayerLocation = playerLocation;
            Rooms = rooms;
        }

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
