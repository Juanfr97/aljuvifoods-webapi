using aljuvifoods_webapi.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aljuvifoods_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
<<<<<<< HEAD
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
=======
        private readonly IMailDao _dao;

        public MailController(IMailDao dao)
        {
            this._dao = dao;
        }
        [HttpPost("Email")]
        public async Task<IActionResult> SendMail(string email)
        {
            try
            {
                _dao.SendMail(email);
>>>>>>> 472945196e9027f2fbb455d22a313e79d309d38d
                return Ok();
            }catch (Exception ex) { throw ex; }
        }
    }
}
