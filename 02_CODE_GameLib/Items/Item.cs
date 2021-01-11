using System;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public abstract class Item : RoomObject, IItem
    {
        protected Item(int x, int y) : base(x, y)
        {
        }

        public virtual void OnEnter(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
