namespace ObserverPattern
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);

        void RemoveObserver(IObserver observer);

        void NotifyObserversOfNewOrders();

        void NotifyObserversOrderCooked();

        void NotifyObserversOrderDelivered();

    }
}
