using System;
using System.Collections.Generic;
using System.Linq;
using CODE_GameLib;
using CODE_GameLib.Enums;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Doors;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class ConnectionFactory
    {
        private static readonly Dictionary<string, Direction> ConvertLocation = new Dictionary<string, Direction>
        {
            {"NORTH", Direction.North},
            {"EAST", Direction.West},
            {"SOUTH", Direction.South},
            {"WEST", Direction.East},
            {"UPPER", Direction.Upper},
            {"LOWER", Direction.Lower}
        };

        public static ((int roomId1, IConnection conn1), (int roomId2, IConnection conn2)) CreateConnection(JObject jConnection, IReadOnlyDictionary<int, IRoom> rooms)
        {
            var actualConnections = GetConnections(jConnection);

            var connectionDoor = GetConnectionDoor(jConnection);

            var (roomId1, conn1) = CreateConnection(actualConnections[0], jConnection, rooms, connectionDoor);
            var (roomId2, conn2) = CreateConnection(actualConnections[1], jConnection, rooms, connectionDoor);

            conn1.Destination = conn2;
            conn2.Destination = conn1;

            return ((roomId1, conn1), (roomId2, conn2));
        }

        private static (int roomId, Connection connection) CreateConnection(JProperty actualConnection, JObject jConnection,
            IReadOnlyDictionary<int, IRoom> rooms, IDoor connectionDoor)
        {
            var roomId = GetRoomId(actualConnection);
            
            var room1 = GetRoom(rooms, roomId);
            
            var direction1 = GetDirection(actualConnection);
            
            var (x1, y1) = GetLocation(jConnection, room1, direction1);

            var connection = new Connection(room1, direction1, x1, y1, connectionDoor);
            
            return (roomId, connection);
        }

        private static IDoor GetConnectionDoor(JObject jConnection)
        {
            if (jConnection.ContainsKey("door"))
                return DoorFactory.CreateDoor(jConnection["door"]);

            if (jConnection.ContainsKey("ladder"))
                return DoorFactory.CreateLadder();

            return null;
        }

        private static (int x, int y) GetLocation(JObject jConnection, IRoom room, Direction direction)
        {
            if (jConnection.ContainsKey("ladder"))
                return GetLadderLocation(jConnection, room, direction);
            
            return GetRegularLocation(room, direction);
        }

        private static (int x, int y) GetRegularLocation(IRoom room, Direction direction)
        {
            var x = direction.IsVertical()
                ? (room.Width + 1) / 2 - 1
                : direction == Direction.West
                    ? 0
                    : room.Width - 1;

            var y = direction.IsHorizontal()
                ? (room.Height + 1) / 2 - 1
                : direction == Direction.South
                    ? 0
                    : room.Height - 1;

            return (x, y);
        }

        private static (int x, int y) GetLadderLocation(JObject jConnection, IRoom room, Direction direction)
        {
            var prefix = "upper";
            if (direction == Direction.Lower)
                prefix = "lower";

            var x = jConnection["ladder"][$"{prefix}X"].Value<int>();
            var y = jConnection["ladder"][$"{prefix}X"].Value<int>();

            if (!room.IsWithinBoundaries(x, y))
                throw new InvalidConnectionException($"Invalid ladder location: {x}, {y}");

            return (x, y);
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
                throw new InvalidConnectionException(
                    $"Invalid location in provided level file: {actualConnection.Name}", e);
            }
        }

        private static JProperty[] GetConnections(JObject jConnection)
        {
            var properties = jConnection.Properties()
                .Where(jp => ConvertLocation.ContainsKey(jp.Name)).ToArray();

            if (properties.Length != 2)
                throw new InvalidConnectionException(
                    $"Invalid amount of locations in connection: {properties.Length}. {jConnection}");

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
