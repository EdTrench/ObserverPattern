using System.Linq;

namespace TheObserverPattern.Apps
{
    public class DriverApp : AppBase
    {
        public override string Display()
        {
            var result = Orders
                .Where(y => y.DeliveredDate == null)
                .OrderBy(x => x.PlacedDate).FirstOrDefault()?
                .DeliveryPostcode;

            return $"Next Delivery Postcode: {result}";
        }
    }
}
