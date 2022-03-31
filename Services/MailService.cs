
using aljuvifoods_webapi.Services.Contracts;
using System.Net;
using System.Net.Mail;

namespace aljuvifoods_webapi.Services
{
    public abstract class MailService : IMailService
    {
        private SmtpClient smtpClient { get; set; }
        protected string senderMail { get; set; }
        protected string password { get; set; }
        protected string host { get; set; }
        protected int port { get; set; }
        protected bool ssl { get; set; }

        protected void InitSmtp()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(senderMail, password);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
        }

        public async Task Send(string subject, string body, List<string> recipien)
        {
            var msg = new MailMessage();
            try
            {
                msg.From = new MailAddress(senderMail);
                foreach (string mail in recipien)
                {
                    msg.To.Add(mail);
                }
                msg.Subject = subject;
                msg.Body = body;
                msg.Priority=MailPriority.Normal;
                smtpClient.Send(msg);
            }
            catch (Exception ex) { }
            finally
            {
                msg.Dispose();
                smtpClient.Dispose();
            }
        }
    }
}
