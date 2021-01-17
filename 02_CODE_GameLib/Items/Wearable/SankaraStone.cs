using CODE_GameLib.Interfaces.Items.Wearable;

namespace CODE_GameLib.Items.Wearable
{
    /// <summary>
    /// Implements a Sankara stone, necessary to win the game
    /// </summary>
    public class SankaraStone : WearableItem, ISankaraStone
    {
        ///<inheritdoc/>
        public SankaraStone(int x, int y) : base(x, y)
        {
        }
    }
}
