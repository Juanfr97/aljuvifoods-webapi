using aljuvifoods_webapi.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aljuvifoods_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailDao mailDao;

        public MailController(IMailDao mailDao)
        {
            this.mailDao = mailDao;
        }

        [HttpPost("Email")]
        public async Task<IActionResult> SendEmail(string email)
        {
            try
            {
                mailDao.SendMail(email);
                return Ok();
            }catch (Exception ex) { throw ex; }
        }
    }
}
