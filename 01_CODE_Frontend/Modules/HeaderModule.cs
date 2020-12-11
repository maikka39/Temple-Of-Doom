using System;
using System.Threading.Tasks;
using CODE_GameLib;
using CODE_GameLib.Interfaces;

namespace CODE_Frontend.Modules
{
    public class HeaderModule
    {
        private DateTime _startTime;
        private Game _game;

        public HeaderModule()
        {
            _startTime = DateTime.Now;
        }
        
        public string PlayTime => $"Playtime: {DateTime.Now.Subtract(_startTime):hh\\:mm\\:ss}";
        
        public static string GetLives (IPlayer player) => $"Lives: {player.Lives}";
        
        public string Render(Game game)
        {
            return $"{GetLives(game.Player)} - {PlayTime}";
        }
    }
}
