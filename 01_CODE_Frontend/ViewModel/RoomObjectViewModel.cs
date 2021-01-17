using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.BoobyTraps;
using CODE_GameLib.Interfaces.Items.Wearable;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_Frontend.ViewModel
{
    public class RoomObjectViewModel : IViewModel
    {
        private readonly ILocation _item;

        /// <summary>
        /// Creates a new instances from an item
        /// </summary>
        /// <param name="item">The item to create the view model for</param>
        public RoomObjectViewModel(ILocation item)
        {
            _item = item;
        }

        ///<inheritdoc/>
        public int X => _item.X;
        
        ///<inheritdoc/>
        public int Y => _item.Y;
        
        ///<inheritdoc/>
        public ConsoleText View => GetItemConsoleText(_item);

        /// <summary>
        /// Gets the appropriate ConsoleText for a room object 
        /// </summary>
        /// <param name="location">The room object to get the console text for</param>
        /// <returns>The console text for a room object</returns>
        private static ConsoleText GetItemConsoleText(ILocation location)
        {
            return location switch
            {
                ISankaraStone _ => new ConsoleText("S", ConsoleColor.DarkYellow),
                IDisappearingTrap _ => new ConsoleText("@"),
                IBoobyTrap _ => new ConsoleText("Ο"),
                IKey key => new ConsoleText("K", Utils.Color.ColorToConsoleColor(key.Color)),
                IPressurePlate _ => new ConsoleText("T"),
                IIceTile _ => new ConsoleText("~", ConsoleColor.Blue),
                _ => new ConsoleText("?")
            };
        }
    }
}
