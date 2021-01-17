using System;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public abstract class Item : RoomObject, IItem
    {
        /// <summary>
        /// Creates a new instance of an item
        /// </summary>
        /// <param name="x">The x coordinate of the item</param>
        /// <param name="y">The y coordinate of the item</param>
        protected Item(int x, int y) : base(x, y)
        {
        }

        ///<inheritdoc/>
        public virtual void OnEnter(IPlayer player)
        {
        }
    }
}
