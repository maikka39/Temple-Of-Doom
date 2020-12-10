using System;
using System.Collections.Generic;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class PlayerLocation : IPlayerLocation, IObservable<IPlayerLocation>
    {
        public IRoom Room { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
        
        private readonly List<IObserver<IPlayerLocation>> _observers;

        public PlayerLocation(IRoom room, int x, int y, List<IObserver<IPlayerLocation>> observers)
        {
            Room = room;
            X = x;
            Y = y;
            _observers = observers;
        }
        
        public IDisposable Subscribe(IObserver<IPlayerLocation> observer)
        {
            if (! _observers.Contains(observer)) {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
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