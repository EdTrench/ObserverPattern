using System.Collections.Generic;
using ObserverPattern.Models;

namespace ObserverPattern
{
    public interface IObserver
    {
        void Register(ISubject orderData);

        void AddOrders(List<Order> orders);

        void OrderCooked(string orderId);

        void OrderDelivered(string orderId);
    }
}
