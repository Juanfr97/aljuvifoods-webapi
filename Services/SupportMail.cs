using aljuvifoods_webapi.Services.Contracts;

namespace aljuvifoods_webapi.Services
{
    public class SupportMail : MailService
    {
        public SupportMail()
        {
            senderMail = "aljuvifoods@gmail.com";
            password = "aljuvi1234";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            InitSmtp();
        }
    }
}
