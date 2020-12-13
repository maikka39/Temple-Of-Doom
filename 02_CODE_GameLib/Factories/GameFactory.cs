using CODE_GameLib.Interfaces;
using System.Collections.Generic;

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
