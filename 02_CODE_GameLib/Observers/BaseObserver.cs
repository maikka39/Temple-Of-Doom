using System;

namespace CODE_GameLib.Observers
{
    public class BaseObserver : IObserver<object>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(object value)
        {
            throw new NotImplementedException();
        }
    }
}
