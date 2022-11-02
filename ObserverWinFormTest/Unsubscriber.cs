using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverWinFormTest
{
    internal class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<Message>> _observers;
        private readonly IObserver<Message> _observer;

        public Unsubscriber(List<IObserver<Message>> observers, IObserver<Message> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
