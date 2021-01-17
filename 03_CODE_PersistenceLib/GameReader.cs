using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_PersistenceLib.Factories;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib
{
    public static class GameReader
    {
        public static IGame Read(string filePath)
        {
            var rooms = new Dictionary<int, IRoom>();
            IPlayer player;

            try
            {
                var json = JObject.Parse(File.ReadAllText(filePath));

                var connections = new Dictionary<int, List<IConnection>>();

                SetRooms(json, connections, rooms);
                SetConnections(json, connections, rooms);

                var playerJToken = json["player"];
                var playerStartLocation = EntityLocationFactory.CreateEntityLocation(rooms, playerJToken);
                player = PlayerFactory.CreatePlayer(playerJToken, playerStartLocation);
            }
            catch (Exception e)
            {
                throw new JsonException("The provided JSON level file is not valid.", e);
            }

            return GameFactory.CreateGame(player);
        }

        private static void SetRooms(JObject json, IDictionary<int, List<IConnection>> connections,
            IDictionary<int, IRoom> rooms)
        {
            foreach (var roomJObject in json["rooms"].Select(x => x as JObject))
            {
                var (room, roomId) = RoomFactory.CreateRoom(roomJObject, connections);
                rooms.Add(roomId, room);
            }
        }

        private static void SetConnections(JObject json, IReadOnlyDictionary<int, List<IConnection>> connections,
            IReadOnlyDictionary<int, IRoom> rooms)
        {
            if (!json.ContainsKey("connections")) return;

            foreach (var jConnection in json["connections"].Children<JObject>())
            {
                var ((roomId1, conn1), (roomId2, conn2)) =  ConnectionFactory.CreateConnection(jConnection, rooms);

                connections[roomId1].Add(conn1);
                connections[roomId2].Add(conn2);
            }
        }

        public class JsonException : Exception
        {
            public JsonException(string message, Exception inner)
                : base(message, inner)
            {
            }

            public JsonException(string message)
                : base(message)
            {
            }
        }
    }
}
