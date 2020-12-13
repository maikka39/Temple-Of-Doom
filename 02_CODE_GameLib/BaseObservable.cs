using System;
using System.Collections.Generic;

namespace CODE_GameLib
{
    public abstract class BaseObservable<T>
    {
        private List<IObserver<T>> observers = new List<IObserver<T>>();

        public IDisposable Subscribe(IObserver<T> observer)
        {
            observers.Add(observer);
            return new Subscription(() => observers.Remove(observer));
        }

        protected void NotifyObservers(T subject)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(subject);
            }
        }

    }

    public class Subscription : IDisposable
    {
        private readonly Action unsubscriber;

        public Subscription(Action unsubscriber)
        {
            this.unsubscriber = unsubscriber;
        }

        public void Dispose()
        {
            unsubscriber.Invoke();
        }
    }
}
