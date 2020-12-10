using System;
using System.Collections.Generic;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class PlayerLocationHandler : IObservable<IPlayerLocation>
    {
        private List<IObserver<IPlayerLocation>> _observers;
        private IPlayerLocation _playerLocation;

        public PlayerLocationHandler(IPlayerLocation playerLocation)
        {
            _playerLocation = playerLocation;
            _observers = new List<IObserver<IPlayerLocation>>();
        }
        
        public IDisposable Subscribe(IObserver<IPlayerLocation> observer)
        {
            if (! _observers.Contains(observer)) {
                _observers.Add(observer);
                observer.OnNext(_playerLocation);
            }
            return new Unsubscriber(_observers, observer);
        }

        public void PlayerMoved()
        {
            
        }
    }
    
    internal class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<IPlayerLocation>> _observers;
        private readonly IObserver<IPlayerLocation> _observer;

        internal Unsubscriber(List<IObserver<IPlayerLocation>> observers, IObserver<IPlayerLocation> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}