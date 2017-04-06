using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace FindCaabs
{
    [ServiceContract]
    public interface ICustomer
    {
        [OperationContract]
        void AddCustomer(Customer Cust);
    }
    
    
}
