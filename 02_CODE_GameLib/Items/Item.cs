using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public abstract class Item: InteractableRoomObject, IItem
    {
        protected Item(int x, int y) : base(x, y)
        {
        }
    }
}
