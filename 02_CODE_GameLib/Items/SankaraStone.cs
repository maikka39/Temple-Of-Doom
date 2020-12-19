using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Items
{
    public class SankaraStone : Wearable, ISankaraStone
    {
        public SankaraStone(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
