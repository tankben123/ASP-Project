using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using WebAppIdentityCore.Models;

namespace WebAppIdentityCore
{
    public class Helper
    {
        public static bool SendEmail(IConfiguration configuration, Email obj)
        {
            try
            {
                IConfiguration section = configuration.GetSection("Email:Gmail");
                SmtpClient client = new SmtpClient(section.GetValue<string>("Host"), section.GetValue<int>("Port"))
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential(section.GetValue<string>("Address"), section.GetValue<string>("Password")),
                    EnableSsl = true,
                };

                MailAddress from = new MailAddress(section.GetValue<string>("Address"));
                MailAddress to = new MailAddress(obj.Address);
                MailMessage message = new MailMessage(from, to)
                {
                    Subject = obj.Subject,
                    Body = obj.Body,
                    From = from,
                    IsBodyHtml = obj.IsBodyHtml
                };

                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
