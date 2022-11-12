using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;

namespace ZeroHunger.Models
{
    public class EmployeeRegistrationConfirmMail
    {
        public static string Mail(MailData data)
        {
            var client = MailServer.Server();
            MailAddress from = new MailAddress("19-41621-3@student.aiub.edu", "Zero Hunger");
            MailAddress to = new MailAddress(data.Email, data.Name);
            MailMessage message = new MailMessage(from, to);
            message.Subject = data.Subject;
            message.Body = data.Body;

            try
            {
                client.Send(message);
                return "success";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}
//private static void Main()
//{
//    Execute().Wait();
//}

