

namespace AnkAsset.Core
{
    using System;
   
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;
    using System.Data.SqlClient;
    using System.Data;
    using System.Net;
    using System.Configuration;
    using System.Net.Mail;

    public class EmailInfoProvider
    {


        /// <summary>
        /// insert information for apply leave
        /// </summary>
        /// <param name="objLeaveInfo">LeaveInfo type objLeaveInfo</param>
        /// <returns>returns no of affected rows</returns>
        public static void SendMailMethod(string to, string EmailFrom, string Subject, string Body)
        {
            int PortNo = 0;
            if (ConfigurationManager.AppSettings["SmtpPort"] != null)
            {
            PortNo = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
            }
            string Host = ConfigurationManager.AppSettings["SmtpHost"];

            string UserName = ConfigurationManager.AppSettings["UserName"];
            string Password = ConfigurationManager.AppSettings["Password"];


            MailMessage message = new MailMessage(EmailFrom, to);
            message.Subject = Subject;
            message.Body = Body;
            //For testing replace the local host path with your lost host path and while making online replace with your website domain name

            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(Host, PortNo);
            System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential(UserName, Password);
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential;
            try
            {
                client.Send(message);
                // ShowMessage("Email Sending successfully...!");
            }
            catch (Exception ex)
            {

            }

        }

    }    
        
}

