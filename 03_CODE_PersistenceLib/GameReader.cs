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
        /// <summary>
        /// Reads the specified file and parses it to a game
        /// </summary>
        /// <param name="filePath">The filepath of the file to read</param>
        /// <returns>A playable game</returns>
        /// <exception cref="JsonException">Thrown if the provided level file is invalid</exception>
        public static IGame Read(string filePath)
        {
            try
            {
                var rooms = new Dictionary<int, IRoom>();

                var json = JObject.Parse(File.ReadAllText(filePath));

                var connections = new Dictionary<int, List<IConnection>>();

                SetRooms(json, connections, rooms);
                SetConnections(json, connections, rooms);

                var playerJToken = json["player"];
                var playerStartLocation = EntityLocationFactory.CreateEntityLocation(rooms, playerJToken);
                var player = PlayerFactory.CreatePlayer(playerJToken, playerStartLocation);
                
                return GameFactory.CreateGame(player);
            }
            catch (Exception e)
            {
                throw new JsonException("The provided JSON level file is not valid.", e);
            }
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

        /// <summary>
        /// Json exception which is thrown in case of an invalid level file
        /// </summary>
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
