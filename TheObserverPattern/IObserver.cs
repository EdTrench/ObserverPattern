using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheObserverPattern
{
    interface IObserver
    {
        void update(float temp, float humidity, float pressure);
    }
}
