using CODE_GameLib.Interfaces;
using System;
using System.Collections.Generic;

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
            var playerLocationObserver = new PlayerLocationObserver(this, player.Location);
            var playerObserver = new PlayerObserver(this, player);
        }

        public void Tick(TickData tickData)
        {
            if (tickData.Quit)
                Destroy();

            if (tickData.MovePlayer != null)
                Player.Move((Direction)tickData.MovePlayer);
        }

        public void Destroy()
        {
            Quit = true;
            Update();
        }

        public void Update()
        {
            Updated?.Invoke(this, this);
        }
    }
}