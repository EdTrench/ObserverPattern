using System.Collections.Generic;

namespace TheObserverPattern
{
    public class WeatherData : ISubject
    {
        private readonly IList<IObserver> _observers = new List<IObserver>();
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (var o in _observers)
            {
                o.Update(_temperature, _humidity, _pressure);
            }
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
        }
    }
}
