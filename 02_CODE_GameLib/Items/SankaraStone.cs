using CODE_GameLib.Interfaces.Items;
using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Items
{
    public class SankaraStone : ISankaraStone
    {
        public int X { get; }
        public int Y { get; }

        public SankaraStone(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}