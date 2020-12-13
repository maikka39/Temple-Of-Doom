using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Items;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;

namespace CODE_GameLib.Factories
{
    public static class ItemFactory
    {
        public static IItem CreateItem(JToken itemJToken)
        {
            var x = itemJToken["x"].Value<int>();
            var y = itemJToken["y"].Value<int>();

            return itemJToken["type"].Value<string>() switch
            {
                "boobietrap" => new BoobyTrap(x, y, itemJToken["damage"].Value<int>()),
                "disappearing boobietrap" => new DisapearingTrap(x, y, itemJToken["damage"].Value<int>()),
                "sankara stone" => new SankaraStone(x, y),
                "key" => new Key(x, y, Color.FromName(itemJToken["color"].Value<string>())),
                "pressure plate" => new PressurePlate(x, y),
                _ => throw new ArgumentException("Invalid item type")
            };
        }
    }
}
