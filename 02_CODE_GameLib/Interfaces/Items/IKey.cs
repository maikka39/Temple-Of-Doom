using System;

namespace CODE_GameLib.Interfaces.Items
{
    public interface IKey : IItem
    {
        public ConsoleColor KeyColor { get; }
    }
}