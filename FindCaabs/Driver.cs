using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace FindCaabs
{
    [DataContract]
   public  class Driver
    {
        [DataMember]
        public string driver_FName;
        [DataMember]
        public string driver_LName;
        [DataMember]
        public string driver_Contact_Number;
        [DataMember]
        public string driver_EmailAddress;
        [DataMember]
        public string driver_License_Details;
        [DataMember]
        public string driver_Pincode;
        [DataMember]
        public string driver_Country;
        [DataMember]
        public bool driver_Account_Verfied;
        [DataMember]
        public string driver_Cabid;

    }
}
