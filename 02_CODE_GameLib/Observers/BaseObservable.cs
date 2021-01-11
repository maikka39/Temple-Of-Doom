using System;
using System.Collections.Generic;

namespace CODE_GameLib.Observers
{
    public abstract class BaseObservable<T>
    {
        private readonly List<IObserver<T>> _observers = new List<IObserver<T>>();

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _observers.Add(observer);
            return new Subscription(() => _observers.Remove(observer));
        }

        protected void NotifyObservers(T subject)
        {
            // Loop over a copy of the list as the original one might change
            foreach (var observer in new List<IObserver<T>>(_observers))
                observer.OnNext(subject);
        }
    }

    public class Subscription : IDisposable
    {
        private readonly Action _unsubscriber;

        public Subscription(Action unsubscriber)
        {
            _unsubscriber = unsubscriber;
        }

        public void Dispose()
        {
            _unsubscriber.Invoke();
        }
    }
}
