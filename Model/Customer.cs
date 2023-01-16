using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace CustomerRewardSystem.Model
{
    public class Customer
    {
        public int CustomerId { get; set; } = 0;
        public string CustomerName { get; set; } = "";
        public DateTime OrderDate { get; set; }
        public double Price { get; set; } = 0;
        public double RewardPoint { get; set; } = 0;
        public string OrderMonthYear { get; set; } = "";
    }

    public class CustomerReward
    {
        public double totalRewardPoint { get; set; } = 0;
    }
}
