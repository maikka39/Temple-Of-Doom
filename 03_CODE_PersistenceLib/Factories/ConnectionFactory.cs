using System;
using CODE_GameLib.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces.Doors;
using CODE_PersistenceLib;

namespace CODE_GameLib.Factories
{
    public static class ConnectionFactory
    {
        private static readonly Dictionary<string, Direction> ConvertLocation = new Dictionary<string, Direction>
        {
            {"NORTH", Direction.North},
            {"EAST", Direction.East},
            {"SOUTH", Direction.South},
            {"WEST", Direction.West}
        };
        
        public static void CreateConnection(JObject jConnection, IReadOnlyDictionary<int, IRoom> rooms, out IConnection conn1, out IConnection conn2, out int roomId1, out int roomId2)
        {
            var actualConnections = GetConnections(jConnection);

            roomId1 = GetRoomId(actualConnections[0]);
            roomId2 = GetRoomId(actualConnections[1]);

            var direction1 = GetDirection(actualConnections[0]);
            var direction2 = GetDirection(actualConnections[1]);
            
            var room1 = GetRoom(rooms, roomId1);
            var room2 = GetRoom(rooms, roomId2);

            IDoor connectionDoor = null;

            if (jConnection.ContainsKey("door"))
                connectionDoor = DoorFactory.CreateDoor(jConnection["door"]);

            conn1 = new Connection(room1, direction1, connectionDoor);
            conn2 = new Connection(room2, direction2, connectionDoor);

            conn1.Destination = conn2;
            conn2.Destination = conn1;
        }

        private static int GetRoomId(JProperty actualConnection)
        {
            return actualConnection.Value.Value<int>();
        }
        
        private static IRoom GetRoom(IReadOnlyDictionary<int, IRoom> rooms, int roomId)
        {
            try
            {
                return rooms[roomId];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new InvalidConnectionException($"Invalid room id in provided level file: {roomId}", e);
            }
        }
        
        private static Direction GetDirection(JProperty actualConnection)
        {
            try
            {
                return ConvertLocation[actualConnection.Name];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new InvalidConnectionException($"Invalid location in provided level file: {actualConnection.Name}", e);
            }
        }

        private static JProperty[] GetConnections(JObject jConnection)
        {
            var properties =  jConnection.Properties()
                .Where(jp => ConvertLocation.ContainsKey(jp.Name)).ToArray();

            if (properties.Length != 2)
                throw new InvalidConnectionException($"Invalid amount of locations in connection: {properties.Length}. {jConnection}");

            return properties;
        }
    }
    
    public class InvalidConnectionException : GameReader.JsonException
    {
        public InvalidConnectionException(string message, Exception inner)
            : base(message, inner)
        {
        }
        
        public InvalidConnectionException(string message)
            : base(message)
        {
        }
    }
}
