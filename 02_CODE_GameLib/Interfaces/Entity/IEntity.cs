using System;
using CODE_GameLib.Enums;

namespace CODE_GameLib.Interfaces.Entity
{
    public interface IEntity : IObservable<IEntity>
    {
        public IEntityLocation Location { get; }
        public int Lives { get; }
        public bool Died { get; }

        public void ReceiveDamage(int damage);
        public bool Move(Direction direction);
    }
}
