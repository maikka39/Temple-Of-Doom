using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public abstract class Item: IItem
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public void OnEnter(IPlayer player)
        {
            throw new System.NotImplementedException();
        }
    }
}
