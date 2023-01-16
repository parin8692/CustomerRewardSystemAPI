using CustomerRewardSystem.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace CustomerRewardSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        db dbObj = new db();
        string msg = string.Empty;

        [HttpGet]
        public async Task<List<Customer>> GetCustomer()
        {
            List<Customer> customerList = new List<Customer>();
            Customer customer = new Customer();
            DataSet ds = dbObj.GetCustomer(customer, out msg);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                customerList.Add(new Customer
                {
                    CustomerId = Convert.ToInt32(dr["customerId"]),
                    CustomerName = dr["customerName"].ToString()
                });
            }

            return customerList;
        }

        [HttpGet("{custId}")]
        public async Task<List<Customer>> GetCustomerRewardHistory(int custId)
        {
            List<Customer> customerList = new List<Customer>();
            Customer customer = new Customer();
            customer.CustomerId = custId;
            DataSet ds = dbObj.GetCustomerRewardHistory(customer, out msg);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                customerList.Add(new Customer
                {
                    CustomerId = Convert.ToInt32(dr["customerId"]),
                    CustomerName = dr["customerName"].ToString(),
                    OrderDate = Convert.ToDateTime(dr["orderDate"]),
                    Price = Convert.ToDouble(dr["price"]),
                    RewardPoint = Convert.ToDouble(dr["rewardPoint"])
                });
            }

            return customerList;
        }

        [HttpGet]
        [Route("Reward/{custId}")]
        public async Task<List<Customer>> GetMonthlyPointByCustomerId(int custId)
        {
            List<Customer> customerList = new List<Customer>();
            Customer customer = new Customer();
            customer.CustomerId = custId;
            DataSet ds = dbObj.GetMonthlyPointByCustomerId(customer, out msg);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                customerList.Add(new Customer
                {
                    OrderMonthYear = (CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(dr["Month"])) + " " + Convert.ToInt32(dr["Year"])).ToString(),
                    RewardPoint = Convert.ToDouble(dr["rewardPoint"])
                });
            }

            return customerList;
        }

        [HttpGet]
        [Route("MontlyReward/{custId}")]
        public async Task<CustomerReward> GetCustomerTotalRwardById(int custId)
        {
            Customer customer = new Customer();
            customer.CustomerId = custId;
            DataSet ds = dbObj.GetMonthlyPointByCustomerId(customer, out msg);

            CustomerReward customerReward = new CustomerReward();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                customerReward.totalRewardPoint += Convert.ToDouble(dr["rewardPoint"]);
            }

            return customerReward;
        }
    }
}
