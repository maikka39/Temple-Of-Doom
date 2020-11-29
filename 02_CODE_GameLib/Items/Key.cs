using System;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public class Key : IKey
    {
        public int X { get; }
        public int Y { get; }
        public ConsoleColor KeyColor { get; }

        public Key(int x, int y, ConsoleColor key)
        {
            X = x;
            Y = y;
            KeyColor = key;
        }
    }
}