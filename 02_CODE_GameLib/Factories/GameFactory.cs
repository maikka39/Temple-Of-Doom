using System.Collections.Generic;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib.Factories
{
    public class GameFactory
    {
        public static IGame CreateGame(IPlayer player, IEnumerable<IRoom> rooms)
        {
            return new Game(player, rooms);
        }
    }
}
