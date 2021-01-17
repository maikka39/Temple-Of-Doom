using System;
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.BoobyTraps;
using CODE_GameLib.Interfaces.Items.Wearable;
using CODE_GameLib.Interfaces.Tiles;

namespace CODE_Frontend.ViewModel
{
    public class RoomObjectViewModel
    {
        private readonly IRoomObject _item;

        public RoomObjectViewModel(IRoomObject item)
        {
            _item = item;
        }

        public int X => _item.X;
        public int Y => _item.Y;
        public ConsoleText View => GetItemConsoleText(_item);

        private static ConsoleText GetItemConsoleText(IRoomObject roomObject)
        {
            return roomObject switch
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
