using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace FindCaabs
{
    public class AddCustomerService : ICustomer
    {
        public void AddCustomer(Customer cust)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ECSConnectionString"].ConnectionString;

        }
    }
}
