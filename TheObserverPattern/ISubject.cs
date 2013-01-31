using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheObserverPattern
{
    interface ISubject
    {
        void registerObserver(IObserver o);
        void removeObserver(IObserver o);
        void notifyObservers();
    }
}
