using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;

namespace CustomerRewardSystem.Model
{
    public class db
    {

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-A03460K2;Initial Catalog=customerrewardsystem;User ID=sa;Password=123;Integrated Security=True");
        //public db()
        //{
        //    var configuration = GetConfiguration();
        //    con = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        //}

        //public IConfigurationRoot GetConfiguration()
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json", optional: true, reloadOnChange: true);
        //    return builder.Build();
        //}

        public DataSet GetCustomer(Customer cust, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            
            try
            {
                con.Open();
                
                SqlCommand cmd = new SqlCommand("getAllCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return ds;
        }

        public DataSet GetCustomerRewardHistory(Customer cust, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("getCustomerRewardHistory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerId", cust.CustomerId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return ds;
        }

        public DataSet GetMonthlyPointByCustomerId(Customer cust, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("getMonthlyPointByCustomerId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerId", cust.CustomerId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return ds;
        }
    }
}
