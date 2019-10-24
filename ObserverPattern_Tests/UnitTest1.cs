using NUnit.Framework;
using TheObserverPattern;

namespace TheObserverPattern_Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            // act
            var weatherData = new WeatherData();
            var currentConditionsDisplay = new CurrentConditionsDisplay();

            // arrange
            currentConditionsDisplay.Register(weatherData);
            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.NotifyObservers();

            // assert
            Assert.AreEqual(currentConditionsDisplay.Display(), "Current conditions: 80 F degrees and 65% humidity");
        }
    }
}
