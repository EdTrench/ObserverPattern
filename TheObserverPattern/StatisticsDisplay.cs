using System.Collections.Generic;
using System.Linq;

namespace TheObserverPattern
{
    public class StatisticsDisplay : DisplayBase
    {
        private float _averageTemperature;
        private float _maximumTemperature;
        private float _minimumTemperature;
        private static List<float> Temperatures { get; } = new List<float>();

        public override void Update(float temperature, float humidity, float pressure)
        {

            Temperatures.Add(temperature);

            if ((temperature <= _minimumTemperature) || (Temperatures.Count == 1))
            {
                _minimumTemperature = temperature;   
            }

            if (temperature > _maximumTemperature)
            {
                _maximumTemperature = temperature;
            }

            _averageTemperature = Temperatures.Sum() / Temperatures.Count;
        }

        public override string Display()
        {
            return $"Avg/Max/Min temperature = {_averageTemperature} / {_maximumTemperature} / {_minimumTemperature}";
        }
    }
}
