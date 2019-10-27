using System;
using System.Linq;
using System.Text;

namespace ObserverPattern.Apps
{
    public class RestaurantApp : AppBase
    {
        public override string Display()
        {
            var result = new StringBuilder();
            var items = Orders
                .Where(x => x.CookedDate == null)
                .OrderBy(x => x.PlacedDate)
                .FirstOrDefault()?
                .Items;

            foreach (var item in items)
            {
                result.Append(item);
                result.Append(Environment.NewLine);
            }

            return $"Ordered Items to prepare = {result}";
        }
    }
}
