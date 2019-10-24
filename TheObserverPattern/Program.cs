using System;
using System.Linq;

namespace TheObserverPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();

            var currentConditionsDisplay = new CurrentConditionsDisplay();
            currentConditionsDisplay.Register(weatherData);

            var statisticsDisplay = new StatisticsDisplay();
            statisticsDisplay.Register(weatherData);

            var heatIndexDisplay = new HeatIndexDisplay();
            heatIndexDisplay.Register(weatherData);

            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.NotifyObservers();

            Console.WriteLine(heatIndexDisplay.Display());


            weatherData.SetMeasurements(82, 70, 29.2f);
            weatherData.NotifyObservers();


            weatherData.SetMeasurements(78, 90, 29.2f);
            weatherData.NotifyObservers();

            
            Console.ReadKey();
        }
    }
}
