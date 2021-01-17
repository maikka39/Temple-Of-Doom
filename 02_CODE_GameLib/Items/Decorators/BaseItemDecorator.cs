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

        public virtual int X => _decoratee.X;
        public virtual int Y => _decoratee.Y;
        public virtual void OnEnter(IPlayer player) => _decoratee.OnEnter(player);
    }
}
