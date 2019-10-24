namespace TheObserverPattern
{
    public class CurrentConditionsDisplay : DisplayBase
    {
        private float _temperature;
        private float _humidity;

        public override void Update(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
        }

        public override string Display()
        {
            return $"Current conditions: {_temperature} F degrees and {_humidity}% humidity";
        }
    }
}
