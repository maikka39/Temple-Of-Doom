using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Tiles;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class RoomFactory
    {
        public static IRoom CreateRoom(JObject roomJObject, IDictionary<int, List<IConnection>> connections,
            out int roomId)
        {
            roomId = roomJObject["id"].Value<int>();

            connections.Add(roomId, new List<IConnection>());

            var items = GetItemsForRoom(roomJObject);
            var tiles = GetTilesForRoom(roomJObject);
            var enemies = GetEnemiesFromRoom(roomJObject);

            var width = roomJObject["width"].Value<int>();
            var height = roomJObject["height"].Value<int>();

            if (height < 3 || height > 50)
                throw new ArgumentException("Height must be between 3 and 50");
            if (width < 3 || width > 50)
                throw new ArgumentException("Width must be between 3 and 50");

            if (height % 2 == 0)
                throw new ArgumentException("Height must be even");
            if (width % 2 == 0)
                throw new ArgumentException("Width must be even");

            return new Room(width, height, items, tiles, enemies, connections[roomId]);
        }

        private static List<IItem> GetItemsForRoom(JObject roomJObject)
        {
            var items = new List<IItem>();

            if (!roomJObject.ContainsKey("items")) return items;

            items.AddRange(roomJObject["items"]!.Select(RoomObjectFactory.CreateItem));

            return items;
        }

        private static List<ITile> GetTilesForRoom(JObject roomJObject)
        {
            var tiles = new List<ITile>();

            if (!roomJObject.ContainsKey("specialFloorTiles")) return tiles;

            tiles.AddRange(roomJObject["specialFloorTiles"]!.Select(RoomObjectFactory.CreateTile));

            return tiles;
        }

        private static List<IEnemy> GetEnemiesFromRoom(JObject roomJObject)
        {
            var enemies = new List<IEnemy>();

            if (!roomJObject.ContainsKey("enemies")) return enemies;

            enemies.AddRange(roomJObject["enemies"]!.Select(enemy => EnemyFactory.CreateEnemy(enemy)));

            return enemies;
        }
    }
}
