using CODE_GameLib.Interfaces;
using System.Collections.Generic;

namespace CODE_GameLib.Factories
{
    public static class GameFactory
    {
        public static IGame CreateGame(IPlayer player)
        {
            return new Game(player);
        }
    }
}
