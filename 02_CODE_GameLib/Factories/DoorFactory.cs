﻿using System;
using System.Drawing;
using CODE_GameLib.Doors;
using CODE_GameLib.Interfaces.Items.Doors;
using CODE_GameLib.Items.Doors;
using Newtonsoft.Json.Linq;

namespace CODE_GameLib.Factories
{
    public static class DoorFactory
    {
        public static IDoor CreateDoor(JToken doorJToken)
        {
            return doorJToken["type"].Value<string>() switch
            {
                "colored" => new ColoredDoor(Color.FromName(doorJToken["color"].Value<string>())),
                "toggle" => new ToggleDoor(),
                "closing gate" => new ClosingDoor(),
                _ => throw new ArgumentException("Invalid door type")
            };
        }
    }
}
