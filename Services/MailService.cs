<<<<<<< HEAD
﻿
using aljuvifoods_webapi.Services.Contracts;
=======
﻿using aljuvifoods_webapi.Services.Contracts;
>>>>>>> 472945196e9027f2fbb455d22a313e79d309d38d
using System.Net;
using System.Net.Mail;

namespace aljuvifoods_webapi.Services
{
<<<<<<< HEAD
    public abstract class MailService : IMailService
=======
    public abstract class MailService:IMailService
>>>>>>> 472945196e9027f2fbb455d22a313e79d309d38d
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
<<<<<<< HEAD
                msg.Priority=MailPriority.Normal;
=======
                msg.Priority = MailPriority.Normal;
>>>>>>> 472945196e9027f2fbb455d22a313e79d309d38d
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
