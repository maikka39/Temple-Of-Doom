using System;
using CODE_GameLib.Interfaces;

namespace CODE_GameLib
{
    public class PlayerLocationObserver : IObserver<IPlayerLocation>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IPlayerLocation value)
        {
            throw new NotImplementedException();
        }
    }
}