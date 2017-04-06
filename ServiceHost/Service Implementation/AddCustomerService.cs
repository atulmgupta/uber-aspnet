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
using SendGrid;

using System.Net;
using System.Net.Mail;

namespace FindCaabs
{
    public class AddCustomerService : ICustomer
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ECSConnectionString"].ConnectionString;

        public void AddCustomer(Customer cust)


        {
            try
            {

           
           

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                    string activationCode = Guid.NewGuid().ToString();
                    
                    SqlCommand com = new SqlCommand("AddCustomer");
                    com.CommandType = CommandType.StoredProcedure;
                    com.Connection = conn;
                    com.Parameters.AddWithValue("@FirstName", cust.customer_Fname);
                    com.Parameters.AddWithValue("@LastName", cust.customer_LName);
                    com.Parameters.AddWithValue("@Contact", cust.customer_Contact_Number);
                    com.Parameters.AddWithValue("@emailAddress", cust.customer_Email_Address);
                    com.Parameters.AddWithValue("@Pincode",cust.customer_Pincode);
                    com.Parameters.AddWithValue("@Country",cust.customer_Country);
                    com.Parameters.AddWithValue("@Promocode", "Promocode");
                    com.Parameters.AddWithValue("@AccountVerified", 0);
                    com.Parameters.AddWithValue("@AccountGuid", activationCode);
                    com.Parameters.AddWithValue("@Password", cust.Customer_Password);
                    Console.WriteLine(cust.Customer_Password);
                    com.ExecuteNonQuery();
                   
                    SendEmail(cust.customer_Email_Address,cust.customer_Fname,activationCode,cust.Url);
            }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
            }

        }

        public void SendEmail(string Emailid,string Username,string ActivationCode,string url)
        {
            try
            {

                string body = "Hello " + Username.Trim() + ",";
                body += "Please click the following link to activate your account";
                body += "<a href = '" + url.Replace("CS.aspx", "CS_Activation.aspx?ActivationCode=" + ActivationCode) + "'>Click here to activate your account.</a>";
                body += "Thanks";

                Console.WriteLine("mail started");
                SendGridMessage mail = new SendGridMessage();
                mail.From = new System.Net.Mail.MailAddress("ecs@ecs.com");
                mail.AddTo(Emailid);
                mail.Subject = "Esteem Cab Service";
                mail.Text = body;

                var credentials = new NetworkCredential("atulgupta1989", "irodov89");
                //XpJw7 - zATsGyNOoyXAWKww
                var transportWeb = new Web(credentials);
                transportWeb.DeliverAsync(mail).Wait();
                Console.WriteLine("send mail");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public int ValidateUser(string Userid,string Password)
        {

            int Result = 0;
            try
            {



                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand com = new SqlCommand("Validateuser");
                    com.Connection = conn;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Userid", Userid);
                    com.Parameters.AddWithValue("@password", Password);

                    SqlParameter OutputParameter = new SqlParameter();
                    OutputParameter.ParameterName = "@Result";
                    OutputParameter.SqlDbType = SqlDbType.Int;
                    OutputParameter.Direction = ParameterDirection.Output;
                    com.Parameters.Add(OutputParameter);

                    com.ExecuteNonQuery();
                    Console.WriteLine(OutputParameter.Value.ToString());
                    Result = Convert.ToInt32(OutputParameter.Value.ToString());
                    Console.WriteLine(Result + "*******");
                }

                return Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
                Console.WriteLine(ex.InnerException);
                return Result;
            }
            //1 valid
            //0 Failed
        }
    }
}
