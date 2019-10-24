namespace TheObserverPattern
{
    public abstract class  DisplayBase : IObserver
    {
        public void Register(ISubject weatherData)
        {
            weatherData.RegisterObserver(this);
        }

        public abstract void Update(float temp, float humidity, float pressure);

        public abstract string Display();
    }
}
