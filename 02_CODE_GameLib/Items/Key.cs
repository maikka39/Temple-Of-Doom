using System;
using System.Drawing;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public class Key : IKey
    {
        public int X { get; }
        public int Y { get; }
        public Color Color { get; }

        public Key(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}