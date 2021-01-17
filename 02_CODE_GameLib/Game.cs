using System;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    public class Game : IGame
    {
        public Game(IPlayer player)
        {
            Player = player;

            Player.Subscribe(new PlayerObserver(this));
            Player.Location.Subscribe(new UpdateRoomOnEntityLocationUpdateObserver(this, Player));
        }

        public event EventHandler<Game> Updated;

        public bool Quit { get; private set; }

        public IPlayer Player { get; }

        public void Tick(TickData tickData)
        {
            if (tickData.Quit)
                Destroy();

            if (tickData.MovePlayer != null)
                if (Player.Move((Direction) tickData.MovePlayer))
                {
                    Update();
                    if (Player.Location.Room.Update())
                    {
                        Player.Location.Room.Check(Player);
                        Update();
                    }
                }

            if (tickData.Shoot)
            {
                Player.Shoot();
                Update();
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
