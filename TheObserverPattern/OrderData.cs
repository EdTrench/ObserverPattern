using System.Collections.Generic;
using TheObserverPattern.Models;

namespace TheObserverPattern
{
    public class OrderData : ISubject
    {
        private readonly IList<IObserver> _observers = new List<IObserver>();
        private readonly List<Order> _orders = new List<Order>();
        private string _deliveredOrderId;
        private string _cookedOrderId;

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObserversOfNewOrders()
        {
            foreach (var observer in _observers)
            {
                observer.AddOrders(_orders);
            }
        }

        public void NotifyObserversOrderCooked()
        {
            foreach (var observer in _observers)
            {
                observer.OrderCooked(_cookedOrderId);
            }
        }

        public void NotifyObserversOrderDelivered()
        {
            foreach (var observer in _observers)
            {
                observer.OrderDelivered(_deliveredOrderId);
            }
        }

        public void AddNewOrder(Order order)
        {
            _orders.Add(order);
        }

        public void OrderCooked(string orderId)
        {
            _cookedOrderId = orderId;
        }

        public void OrderDelivered(string orderId)
        {
            _deliveredOrderId = orderId;
        }
    }
}
