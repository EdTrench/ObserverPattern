using System;
using NUnit.Framework;
using ObserverPattern;
using ObserverPattern.Apps;
using ObserverPattern.Models;

namespace ObserverPattern_Tests
{
    [TestFixture]
    public class ObserverPatternTests
    {
        private Order _order1;
        private Order _order2;
        private Order _order3;

        [OneTimeSetUp]
        public void Init()
        {
            _order1 = new Order
            {
                Id = "test order 1",
                Amount = 9.50m,
                CustomerEmail = "test@test.com",
                DeliveryPostcode = "TE01 1ST",
                Items = new[] { "pizza ham and cheese", "chips", "coke" },
                PlacedDate = DateTime.UtcNow
            };

            _order2 = new Order
            {
                Id = "test order 2",
                Amount = 13.12m,
                CustomerEmail = "test2@test2.com",
                DeliveryPostcode = "TE02 2ND",
                Items = new[] { "chicken jalfrezi", "garlic naan bread", "onion bhaji" },
                PlacedDate = DateTime.UtcNow
            };

            _order3 = new Order
            {
                Id = "test order 3",
                Amount = 11.05m,
                CustomerEmail = "test3@test3.com",
                DeliveryPostcode = "TE03 3RD",
                Items = new[] { "fried plaice - meduim", "chips", "mushy peas" },
                PlacedDate = DateTime.UtcNow
            };
        }

        [Test]
        public void ObserverPattern_ManagerAppDisplaysManagerInformation()
        {
            // act
            var managerApp = new ManagerApp();
            var orderData = new OrderData();

            // arrange
            managerApp.Register(orderData);

            orderData.AddNewOrder(_order1);
            orderData.AddNewOrder(_order2);
            orderData.AddNewOrder(_order3);

            orderData.NotifyObserversOfNewOrders();

            // assert
            Assert.AreEqual(managerApp.Display(), "Number/Avg/Max/Min Order Value = 3 / £11.22 / £13.12 / £9.50");
        }

        [Test]
        public void ObserverPattern_DriverAppDisplaysDriverInformation()
        {
            // act
            var driverApp = new DriverApp();
            var orderData = new OrderData();

            // arrange
            driverApp.Register(orderData);

            orderData.AddNewOrder(_order1);
            orderData.AddNewOrder(_order2);
            orderData.AddNewOrder(_order3);

            orderData.NotifyObserversOfNewOrders();

            // assert
            Assert.AreEqual(driverApp.Display(), "Next Delivery Postcode: TE01 1ST");
        }

        [Test]
        public void ObserverPattern_RestaurantAppDisplaysRestaurantInformation()
        {
            // act
            var restaurantApp = new RestaurantApp();
            var orderData = new OrderData();

            // arrange
            restaurantApp.Register(orderData);

            orderData.AddNewOrder(_order1);
            orderData.AddNewOrder(_order2);
            orderData.AddNewOrder(_order3);

            orderData.NotifyObserversOfNewOrders();

            // assert
            Assert.AreEqual(restaurantApp.Display(),
                "Ordered Items to prepare = pizza ham and cheese\r\nchips\r\ncoke\r\n");
        }

        [Test]
        public void ObserverPattern_RestaurantAppDisplaysRestaurantInformationAfterFirstOrderCooked()
        {
            // act
            var restaurantApp = new RestaurantApp();
            var orderData = new OrderData();

            // arrange
            restaurantApp.Register(orderData);

            orderData.AddNewOrder(_order1);
            orderData.AddNewOrder(_order2);
            orderData.AddNewOrder(_order3);

            orderData.NotifyObserversOfNewOrders();

            orderData.OrderCooked("test order 1");
            orderData.NotifyObserversOrderCooked();

            // assert
            Assert.AreEqual(restaurantApp.Display(),
                "Ordered Items to prepare = chicken jalfrezi\r\ngarlic naan bread\r\nonion bhaji\r\n");
        }

        [Test]
        public void ObserverPattern_DriverAppDisplaysDriverInformationAfterFirstOrderDelivered()
        {
            // act
            var driverApp = new DriverApp();
            var orderData = new OrderData();

            // arrange
            driverApp.Register(orderData);

            orderData.AddNewOrder(_order1);
            orderData.AddNewOrder(_order2);
            orderData.AddNewOrder(_order3);

            orderData.NotifyObserversOfNewOrders();

            orderData.OrderDelivered("test order 1");
            orderData.NotifyObserversOrderDelivered();

            // assert
            Assert.AreEqual(driverApp.Display(), "Next Delivery Postcode: TE02 2ND");
        }

        [Test]
        public void ObserverPattern_ManagerAppDisplaysManagerDeliveredOrdersInformationAfterFirstOrderDelivered()
        {
            // act
            var managerApp = new ManagerApp();
            var orderData = new OrderData();

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

            // arrange
            managerApp.Register(orderData);

            orderData.AddNewOrder(order1);
            orderData.AddNewOrder(order2);
            orderData.AddNewOrder(order3);
            orderData.NotifyObserversOfNewOrders();

            orderData.OrderDelivered("test order 2");
            orderData.NotifyObserversOrderDelivered();

            orderData.OrderDelivered("test order 3");
            orderData.NotifyObserversOrderDelivered();

            // assert
            Assert.AreEqual(managerApp.DeliverdOrders(), "Delivered Orders - test order 2\r\ntest order 3\r\n");
        }
    }
}
