using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ZeroHunger.Models
{
    public class WorkAssignMail
    {
        public static string Mail(MailData data)
        {
            var client = MailServer.Server();
            MailAddress from = new MailAddress("19-41621-3@student.aiub.edu", "Zero Hunger");
            MailAddress to = new MailAddress(data.Email, data.Name);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Work Assign";
            message.Body = @"A work assign to you please check the Zero Hunder website.";

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