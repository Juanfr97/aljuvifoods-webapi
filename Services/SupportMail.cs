<<<<<<< HEAD
﻿using aljuvifoods_webapi.Services.Contracts;

namespace aljuvifoods_webapi.Services
{
    public class SupportMail : MailService
=======
﻿namespace aljuvifoods_webapi.Services
{
    public class SupportMail:MailService
>>>>>>> 472945196e9027f2fbb455d22a313e79d309d38d
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
