using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverWinFormTest
{
    public class MessagesHandler : IObservable<Message>
    {
        private readonly List<IObserver<Message>> _observers;

        public MessagesHandler()
        {
            _observers = new List<IObserver<Message>>();
        }

        public void MessageAdd(Message message)
        {

            foreach (var observer in _observers)
            {
                observer.OnNext(message);
            }
        }

        public IDisposable Subscribe(IObserver<Message> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);

            }

            return new Unsubscriber(_observers, observer);
        }
    }
}
