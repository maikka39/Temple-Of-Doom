using CODE_GameLib.Interfaces;
using System;

namespace CODE_Frontend.Modules
{
    public class HeaderModule
    {
        private DateTime _startTime;

        public HeaderModule()
        {
            _startTime = DateTime.Now;
        }

        public static string Title => "Welcome to Temple of Doom!";

        public string PlayTime => $"Playtime: {DateTime.Now.Subtract(_startTime):hh\\:mm\\:ss}";

        public static string GetLives(IPlayer player) => $"Lives: {player.Lives}";

        public string Render(IGame game)
        {
            return $"{Title}{Environment.NewLine}{GetLives(game.Player)} - {PlayTime}";
        }
    }
}
