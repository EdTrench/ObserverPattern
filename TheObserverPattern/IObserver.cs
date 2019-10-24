namespace TheObserverPattern
{
    public interface IObserver
    {
        void Register(ISubject weatherData);

        void Update(float temp, float humidity, float pressure);

        string Display();
    }
}
