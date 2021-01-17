
using CODE_GameLib.Interfaces;
using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items
{
    public abstract class Item : Location, IItem
    {
        /// <summary>
        /// Creates a new instance of an item
        /// </summary>
        /// <param name="location">The location of the item</param>
        protected Item(ILocation location) : base(location)
        {
        }

        ///<inheritdoc/>
        public virtual void OnEnter(IPlayer player)
        {
        }
    }
}
