using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace FindCaabs
{
   [DataContract]
    public class Customer
    {
        [DataMember]
        public string customer_Fname { get; set; }
        [DataMember]
        public string customer_LName { get; set; }
        [DataMember]
        public string customer_Contact_Number { get; set; }
        [DataMember]
        public string customer_Email_Address { get; set; }
        [DataMember]
        public string customer_Pincode { get; set; }
        [DataMember]
        public string customer_Country { get; set; }
        [DataMember]
        public bool customer_Account_Verified { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Customer_Password { get; set; }

    }
}
