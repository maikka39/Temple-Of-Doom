using CODE_GameLib.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    public class Game : IGame
    {
        private readonly List<Cheat> _enabledCheats = new List<Cheat>();
        public event EventHandler<Game> Updated;

        public bool Quit { get; private set; }

        public IPlayer Player { get; }
        
        public IEnumerable<Cheat> EnabledCheats => _enabledCheats;

        public Game(IPlayer player)
        {
            Player = player;
            
            // ReSharper disable once ObjectCreationAsStatement
            new PlayerLocationObserver(this, player.Location);
            // ReSharper disable once ObjectCreationAsStatement
            new PlayerObserver(this, player);
        }

        public void Tick(TickData tickData)
        {
            if (tickData.Quit)
                Destroy();

            if (tickData.MovePlayer != null)
                Player.Move((Direction)tickData.MovePlayer);

            if (tickData.ToggleCheats != null)
                foreach (var cheat in tickData.ToggleCheats)
                    ToggleCheat(cheat);
        }

        private void ToggleCheat(Cheat cheat)
        {
            if (_enabledCheats.Contains(cheat))
                _enabledCheats.Remove(cheat);
            else
                _enabledCheats.Add(cheat);
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
