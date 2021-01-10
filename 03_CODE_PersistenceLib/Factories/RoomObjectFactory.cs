using System;
using System.Drawing;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Tiles;
using CODE_GameLib.Items;
using CODE_GameLib.Items.Wearable;
using CODE_GameLib.Tiles;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class RoomObjectFactory
    {
        public static IItem CreateItem(JToken itemJToken)
        {
            var (x, y) = GetLocation(itemJToken);

            return itemJToken["type"].Value<string>() switch
            {
                "boobietrap" => new BoobyTrap(x, y, itemJToken["damage"].Value<int>()),
                "disappearing boobietrap" => new DisappearingTrap(x, y, itemJToken["damage"].Value<int>()),
                "sankara stone" => new SankaraStone(x, y),
                "key" => new Key(x, y, Color.FromName(itemJToken["color"].Value<string>())),
                "pressure plate" => new PressurePlate(x, y),
                _ => throw new InvalidRoomObjectException.InvalidItemException("Invalid item type")
            };
        }

        public static ITile CreateTile(JToken tileJToken)
        {
            var (x, y) = GetLocation(tileJToken);
            
            return tileJToken["type"].Value<string>() switch
            {
                "ice" => new IceTile(x, y),
                _ => throw new InvalidRoomObjectException.InvalidTileException("Invalid item type")
            };
        }
        
        private static (int x, int y) GetLocation(JToken itemJToken)
        {
            var x = itemJToken["x"].Value<int>();
            var y = itemJToken["y"].Value<int>();
            return (x, y);
        }
        
        public abstract class InvalidRoomObjectException : GameReader.JsonException
        {
            protected InvalidRoomObjectException(string message)
                : base(message)
            {
            }
            
            public class InvalidItemException : GameReader.JsonException
            {
                public InvalidItemException(string message)
                    : base(message)
                {
                }
            }
            public class InvalidTileException : GameReader.JsonException
            {
                public InvalidTileException(string message)
                    : base(message)
                {
                }
            }
        }
    }
}
