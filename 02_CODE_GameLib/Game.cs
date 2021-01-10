using CODE_GameLib.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    public class Game : IGame
    {
        public event EventHandler<Game> Updated;

        public bool Quit { get; private set; }

        public IPlayer Player { get; }
        

        public Game(IPlayer player)
        {
            Player = player;
            
            // ReSharper disable once ObjectCreationAsStatement
            new EntityLocationObserver(this, player.Location);
            // ReSharper disable once ObjectCreationAsStatement
            new EntityObserver(this, player);
        }

        public void Tick(TickData tickData)
        {
            if (tickData.Quit)
                Destroy();

            if (tickData.MovePlayer != null)
            {
                if (Player.Move((Direction)tickData.MovePlayer))
                    if (Player.Location.Room.Update())
                    {
                        Player.Location.Room.Check(Player);
                        Update();
                    }
            }

            if (tickData.ToggleCheats != null)
            {
                foreach (var cheat in tickData.ToggleCheats)
                    Player.ToggleCheat(cheat);
                
                Update();
            }
                
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
