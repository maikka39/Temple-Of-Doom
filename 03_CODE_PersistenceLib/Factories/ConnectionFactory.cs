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
            {"EAST", Direction.East},
            {"SOUTH", Direction.South},
            {"WEST", Direction.West},
            {"UPPER", Direction.Upper},
            {"LOWER", Direction.Lower}
        };

        public static void CreateConnection(JObject jConnection, IReadOnlyDictionary<int, IRoom> rooms,
            out IConnection conn1, out IConnection conn2, out int roomId1, out int roomId2)
        {
            var actualConnections = GetConnections(jConnection);
            
            var connectionDoor = GetConnectionDoor(jConnection);

            conn1 = CreateConnection(actualConnections[0], jConnection, rooms, connectionDoor, out roomId1);
            conn2 = CreateConnection(actualConnections[1], jConnection, rooms, connectionDoor, out roomId2);

            conn1.Destination = conn2;
            conn2.Destination = conn1;
        }

        private static IConnection CreateConnection(JProperty actualConnection, JObject jConnection,
            IReadOnlyDictionary<int, IRoom> rooms, IDoor connectionDoor, out int roomId)
        {
            roomId = GetRoomId(actualConnection);
            var room1 = GetRoom(rooms, roomId);
            var direction1 = GetDirection(actualConnection);
            GetLocation(jConnection, room1, direction1, out var x1, out var y1);
            return new Connection(room1, direction1, x1, y1, connectionDoor);
        }

        private static IDoor GetConnectionDoor(JObject jConnection)
        {
            if (jConnection.ContainsKey("door"))
                return DoorFactory.CreateDoor(jConnection["door"]);

            if (jConnection.ContainsKey("ladder"))
                return DoorFactory.CreateLadder();

            return null;
        }

        private static void GetLocation(JObject jConnection, IRoom room, Direction direction, out int x, out int y)
        {
            if (jConnection.ContainsKey("ladder"))
                GetLadderLocation(jConnection, room, direction, out x, out y);
            else
                GetRegularLocation(room, direction, out x, out y);
        }

        private static void GetRegularLocation(IRoom room, Direction direction, out int x, out int y)
        {
            x = direction.IsVertical()
                ? room.CenterX
                : direction == Direction.West
                    ? 0
                    : room.Width - 1;

            y = direction.IsHorizontal()
                ? room.CenterY
                : direction == Direction.South
                    ? 0
                    : room.Height - 1;
        }

        private static void GetLadderLocation(JObject jConnection, IRoom room, Direction direction, out int x,
            out int y)
        {
            var prefix = "upper";
            if (direction == Direction.Lower)
                prefix = "lower";

            x = jConnection["ladder"][$"{prefix}X"].Value<int>();
            y = jConnection["ladder"][$"{prefix}X"].Value<int>();

            if (!room.IsWithinBoundaries(x, y))
                throw new InvalidConnectionException($"Invalid ladder location: {x}, {y}");
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
