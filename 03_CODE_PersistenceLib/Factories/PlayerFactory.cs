using System.Collections.Generic;
using CODE_GameLib;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Items;
using CODE_GameLib.Items.Wearable;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class PlayerFactory
    {
        public static IPlayer CreatePlayer(JToken playerJToken, IPlayerLocation playerLocation)
        {
            return new Player(
                playerJToken["lives"].Value<int>(),
                new List<Wearable>(),
                playerLocation
            );
        }
    }
}
