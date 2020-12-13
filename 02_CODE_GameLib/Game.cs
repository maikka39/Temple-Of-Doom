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
            var obs = new PlayerLocationObserver(this, player.Location);
        }

        public void Tick(TickData tickData)
        {
            if (tickData.Quit)
                Destroy();

            if (tickData.MovePlayer != null)
                Player.Move((Direction) tickData.MovePlayer);
        }

        public void Destroy()
        {
            Quit = true;
        }

        public void Update()
        {
            Updated?.Invoke(this, this);
        }
    }
}