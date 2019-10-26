using System;
using System.Linq;
using System.Text;

namespace TheObserverPattern.Apps
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
                result.AppendLine(order.Id);
            }

            return $"Delivered Orders - {result}";
        }
    }
}
