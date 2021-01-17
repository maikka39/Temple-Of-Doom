using System;
using System.Collections.Generic;

namespace CODE_GameLib.Observers
{
    /// <summary>
    /// The boilerplate code for an observable game object.
    /// </summary>
    /// <typeparam name="T">The type for which to create the observable</typeparam>
    public abstract class BaseObservable<T>
    {
        private readonly List<IObserver<T>> _observers = new List<IObserver<T>>();

        /// <summary>
        /// Adds a observer to this object
        /// </summary>
        /// <param name="observer">The observer to add</param>
        /// <returns></returns>
        public virtual IDisposable Subscribe(IObserver<T> observer)
        {
            _observers.Add(observer);
            return new Subscription(() => _observers.Remove(observer));
        }

        /// <summary>
        /// Notify the observers the object has updated
        /// </summary>
        /// <param name="subject"></param>
        protected void NotifyObservers(T subject)
        {
            // Loop over a copy of the list as the original one might change
            foreach (var observer in new List<IObserver<T>>(_observers))
                observer.OnNext(subject);
        }
    }

    /// <summary>
    /// Subscription class used to unsubscribe
    /// </summary>
    public class Subscription : IDisposable
    {
        private readonly Action _unsubscriber;

        public Subscription(Action unsubscriber)
        {
            _unsubscriber = unsubscriber;
        }

        /// <summary>
        /// Unsubscribe
        /// </summary>
        public void Dispose()
        {
            _unsubscriber.Invoke();
        }
    }
}
