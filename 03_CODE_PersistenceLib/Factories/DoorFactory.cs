using System;
using System.Drawing;
using CODE_GameLib.Doors;
using CODE_GameLib.Doors.Decorators;
using CODE_GameLib.Interfaces.Doors;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class DoorFactory
    {
        public static IDoor CreateDoor(JToken doorJToken)
        {
            var door = new Door();
            
            return doorJToken["type"].Value<string>() switch
            {
                "colored" => new ColoredDoorDecorator(door, Color.FromName(doorJToken["color"].Value<string>())),
                "toggle" => new ToggleDoorDecorator(door),
                "closing gate" => new ClosingDoorDecorator(new OpenedDoorDecorator(door)),
                _ => throw new ArgumentException("Invalid door type")
            };
        }

        public static ILadder CreateLadder()
        {
            var door = new Door();
            return new LadderDecorator(new OpenedDoorDecorator(door));
        }
    }
}
