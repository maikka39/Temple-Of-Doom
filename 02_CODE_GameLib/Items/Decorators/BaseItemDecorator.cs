using CODE_GameLib.Interfaces.Entity;
using CODE_GameLib.Interfaces.Items;

namespace CODE_GameLib.Items.Decorators
{
    public abstract class BaseItemDecorator : IItem
    {
        private readonly IItem _decoratee;

        protected BaseItemDecorator(IItem decoratee)
        {
            _decoratee = decoratee;
        }

        ///<inheritdoc/>
        public virtual int X => _decoratee.X;
        
        ///<inheritdoc/>
        public virtual int Y => _decoratee.Y;
        
        ///<inheritdoc/>
        public virtual void OnEnter(IPlayer player) => _decoratee.OnEnter(player);
    }
}
