using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using Newtonsoft.Json.Linq;

namespace CODE_GameLib.Factories
{
    public class RoomFactory
    {
        public static IRoom CreateRoom(JObject roomJObject, IDictionary<int, List<IConnection>> connections, out int roomId)
        {
            roomId = roomJObject["id"].Value<int>();
            
            connections.Add(roomId, new List<IConnection>());

            var items = GetItemsForRoom(roomJObject);

            return new Room(
                roomJObject["width"].Value<int>(),
                roomJObject["height"].Value<int>(),
                items,
                connections[roomId]
            );
        }
        
        private static List<IItem> GetItemsForRoom(JObject roomJObject)
        {
            var items = new List<IItem>();

            if (!roomJObject.ContainsKey("items")) return items;

            items.AddRange(roomJObject["items"].Select(ItemFactory.CreateItem));

            return items;
        }
    }
}
