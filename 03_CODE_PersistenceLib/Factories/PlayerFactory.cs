﻿using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items.Wearable;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using CODE_GameLib.Items;

namespace CODE_GameLib.Factories
{
    public static class PlayerFactory
    {
        public static IPlayer CreatePlayer(JToken playerJToken, IPlayerLocation playerLocation)
        {
            return new Player(
                playerJToken["lives"].Value<int>(),
                new List<Wearable>(),
                playerLocation
            );
        }
    }
}
