using System;
using System.Collections.Generic;
using System.Linq;
using ObserverPattern.Models;

namespace ObserverPattern.Apps
{
    public abstract class  AppBase : IObserver, IApp
    {
        internal List<Order> Orders { get; } = new List<Order>();

        public void AddOrders(List<Order> orders)
        {
            Orders.AddRange(orders);
        }

        public void OrderCooked(string orderId)
        {
            var order = Orders.FirstOrDefault(x => x.Id == orderId);
            if (order != null) order.CookedDate = DateTime.UtcNow;
        }

        public void OrderDelivered(string orderId)
        {
            var order = Orders.FirstOrDefault(x => x.Id == orderId);
            if (order != null) order.DeliveredDate = DateTime.UtcNow;
        }

        public void Register(ISubject orderData)
        {
            orderData.RegisterObserver(this);
        }

        public abstract string Display();

    }
}
