using System;
using ObserverPattern.Apps;
using ObserverPattern.Models;

namespace ObserverPattern.Client.Shell
{
    class Program
    {
        static void Main(string[] args)
        {
            var order1 = new Order
            {
                Id = "test order 1",
                Amount = 9.50m,
                CustomerEmail = "test@test.com",
                DeliveryPostcode = "TE01 1ST",
                Items = new[] { "pizza ham and cheese", "chips", "coke" },
                PlacedDate = DateTime.UtcNow
            };

            var order2 = new Order
            {
                Id = "test order 2",
                Amount = 13.12m,
                CustomerEmail = "test2@test2.com",
                DeliveryPostcode = "TE02 2ND",
                Items = new[] { "chicken jalfrezi", "garlic naan bread", "onion bhaji" },
                PlacedDate = DateTime.UtcNow
            };

            var order3 = new Order
            {
                Id = "test order 3",
                Amount = 11.05m,
                CustomerEmail = "test3@test3.com",
                DeliveryPostcode = "TE03 3RD",
                Items = new[] { "fried plaice - meduim", "chips", "mushy peas" },
                PlacedDate = DateTime.UtcNow
            };

            var managerApp = new ManagerApp();
            var driverApp = new DriverApp();
            var restaurantApp = new RestaurantApp();
            
            var orderData = new OrderData();

            managerApp.Register(orderData);
            driverApp.Register(orderData);
            restaurantApp.Register(orderData);

            orderData.AddNewOrder(order1);
            orderData.AddNewOrder(order2);
            orderData.AddNewOrder(order3);

            orderData.NotifyObserversOfNewOrders();

            Console.WriteLine(managerApp.Display());
            Console.WriteLine(managerApp.DeliverdOrders());
            Console.WriteLine(restaurantApp.Display());
            Console.WriteLine(driverApp.Display());
            orderData.OrderCooked("test order 1");
            Console.WriteLine("==================");
            Console.WriteLine("First Order Cooked");
            orderData.NotifyObserversOrderCooked();
            Console.WriteLine(restaurantApp.Display());
            orderData.OrderDelivered("test order 1");
            Console.WriteLine("==================");
            Console.WriteLine("First Order Delivered");
            orderData.NotifyObserversOrderDelivered();
            Console.WriteLine(driverApp.Display());
            Console.WriteLine(managerApp.DeliverdOrders());
            Console.ReadKey();
        }
    }
}
