using System.Drawing;

namespace CODE_GameLib.Interfaces.Items
{
    public interface IKey : IItem
    {
        public Color Color { get; }
    }
}