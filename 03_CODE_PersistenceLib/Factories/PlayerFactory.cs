using System.Collections.Generic;
using CODE_GameLib;
using CODE_GameLib.Entity;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Items;
using CODE_GameLib.Items.Wearable;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class PlayerFactory
    {
        public static IPlayer CreatePlayer(JToken playerJToken, IEntityLocation entityLocation)
        {
            return new Player(
                playerJToken["lives"].Value<int>(),
                new List<Wearable>(),
                entityLocation
            );
        }
    }
}
