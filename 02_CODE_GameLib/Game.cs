using System;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Observers;

namespace CODE_GameLib
{
    /// <summary>
    /// Implements the main game
    /// </summary>
    public class Game : IGame
    {
        /// <summary>
        /// Creates a new instance from a player
        /// </summary>
        /// <param name="player">The player playing the game</param>
        public Game(IPlayer player)
        {
            Player = player;

            // Add subscription to the player which update the game on changes
            Player.Subscribe(new PlayerObserver(this));
            Player.Location.Subscribe(new UpdateGameEntityLocationObserver(this, Player));
        }

        ///<inheritdoc/>
        public event EventHandler<Game> Updated;

        ///<inheritdoc/>
        public bool Quit { get; private set; }

        ///<inheritdoc/>
        public IPlayer Player { get; }

        /// <summary>
        /// Uses the passed tickdata to update the game
        /// </summary>
        /// <param name="tickData">The tickdate with the changes to handle</param>
        public void Tick(TickData tickData)
        {
            if (tickData.Quit)
                Destroy();

            if (tickData.MovePlayer != null)
                if (Player.Move((Direction) tickData.MovePlayer))
                    if (Player.Location.Room.Update())
                        Player.Location.Room.Check(Player);

            if (tickData.Shoot)
                Player.Shoot();

            if (tickData.ToggleCheats != null)
                foreach (var cheat in tickData.ToggleCheats)
                    Player.ToggleCheat(cheat);
            
            Update();
        }

        /// <summary>
        /// Sets the game to quit and tells the subscribers to update
        /// </summary>
        public void Destroy()
        {
            Quit = true;
            Update();
        }

        ///<inheritdoc/>
        public void Update()
        {
            Updated?.Invoke(this, this);
        }
    }
}
