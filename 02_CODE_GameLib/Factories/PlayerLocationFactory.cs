using CODE_GameLib.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CODE_GameLib.Factories
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
