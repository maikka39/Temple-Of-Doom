using System;
using System.Collections.Generic;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class Game : IGame
    {
        public event EventHandler<Game> Updated;

        public bool Quit { get; private set; }
        
        public IPlayer Player { get; }
        public IEnumerable<IRoom> Rooms { get; }

        public Game(IPlayer player, IEnumerable<IRoom> rooms)
        {
            Player = player;
            Rooms = rooms;
        }

        public void Tick(TickData tickData)
        {
            var didUpdate = false;
            
            if (tickData.Quit)
                Destroy();

            if (tickData.MovePlayer != null)
            {
                Player.Move((Direction) tickData.MovePlayer);
                
                didUpdate = true;
            }

            if (didUpdate)
                Updated?.Invoke(this, this);
        }

        public void Destroy()
        {
            Quit = true;
        }
    }
}
