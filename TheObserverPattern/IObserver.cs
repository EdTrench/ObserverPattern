using System.Collections.Generic;
using TheObserverPattern.Models;

namespace TheObserverPattern
{
    public interface IObserver
    {
        void Register(ISubject orderData);

        void AddOrders(List<Order> orders);

        void OrderCooked(string orderId);

        void OrderDelivered(string orderId);
    }
}
