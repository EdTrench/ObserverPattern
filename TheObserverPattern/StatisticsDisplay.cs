using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheObserverPattern
{
    class StatisticsDisplay : IObserver, IDisplayElement
    {
        private float averageTemperature;
        private float maximumTemperature;
        private float minimumTemperature;
        private static List<float> temps = new List<float>();
        
        private ISubject weatherData;

        public StatisticsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }

        public void update(float temperature, float humidity, float pressure)
        {

            temps.Add(temperature);

            if ((temperature <= this.minimumTemperature) || (temps.Count() == 1))
            {
                this.minimumTemperature = temperature;   
            }

            if (temperature > this.maximumTemperature)
            {
                this.maximumTemperature = temperature;
            }

            this.averageTemperature = temps.Sum() / temps.Count();

            display();
        }

        public void display()
        {
            Console.WriteLine("Avg/Max/Min temperature = " + this.averageTemperature + "/" + maximumTemperature + "/" + this.minimumTemperature);
        }
    }
}
