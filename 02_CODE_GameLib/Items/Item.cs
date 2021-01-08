using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public abstract class Item: IItem
    {
        public int X { get; }
        public int Y { get; }
        
        public Item(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public void OnEnter(IPlayer player)
        {
            throw new System.NotImplementedException();
        }
    }
}
