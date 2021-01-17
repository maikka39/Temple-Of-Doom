using System;

namespace CODE_GameLib.Observers
{
    /// <summary>
    /// Boilerplate code for an observer
    /// </summary>
    /// <typeparam name="T">The type of the object to observe</typeparam>
    public abstract class BaseObserver<T> : IObserver<T>
    {
        ///<inheritdoc/>
        public virtual void OnCompleted()
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public virtual void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public virtual void OnNext(T value)
        {
            throw new NotImplementedException();
        }
    }
}
