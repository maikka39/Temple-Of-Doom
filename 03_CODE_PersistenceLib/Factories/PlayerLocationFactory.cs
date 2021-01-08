using System.Collections.Generic;
using CODE_GameLib;
using CODE_GameLib.Interfaces;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class PlayerLocationFactory
    {
        public static IPlayerLocation CreatePlayerLocation(IReadOnlyDictionary<int, IRoom> rooms, JToken playerJToken)
        {
            return new PlayerLocation(
                rooms[playerJToken["startRoomId"].Value<int>()],
                playerJToken["startX"].Value<int>(),
                playerJToken["startY"].Value<int>()
            );
        }
    }
}
