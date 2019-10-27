using System;
using System.Linq;
using System.Text;

namespace ObserverPattern.Apps
{
    public class ManagerApp : AppBase, IManagerApp
    {
        public override string Display()
        {
            return $"Number/Avg/Max/Min Order Value = {Orders.Count} / £{Math.Round(Orders.Average(x => x.Amount), 2)} / £{Orders.Max(x => x.Amount)} / £{Orders.Min(x => x.Amount)}";
        }

        public string DeliverdOrders()
        {
            var result = new StringBuilder();
            var deliveredOrders = Orders.Where(x => x.DeliveredDate != null);

            foreach (var order in deliveredOrders)
            {
                result.Append(order.Id);
                result.Append(Environment.NewLine);
            }

            if (!deliveredOrders.Any())
            {
                result.Append("0");
            }

            return $"Delivered Orders - {result}";
        }
    }
}
