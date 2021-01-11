using System;

namespace CODE_GameLib.Observers
{
    public abstract class BaseObserver<T> : IObserver<T>
    {
        public virtual void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public virtual void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNext(T value)
        {
            throw new NotImplementedException();
        }
    }
}
