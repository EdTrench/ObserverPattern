using System;

namespace TheObserverPattern.Models
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime PlacedDate { get; set; }
        public decimal Amount { get; set; } 
        public string CustomerEmail { get; set; }
        public string[] Items { get; set; }
        public string DeliveryPostcode { get; set; }
        public DateTime? CookedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
    }
}
