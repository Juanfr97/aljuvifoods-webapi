using aljuvifoods_webapi.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aljuvifoods_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
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
                return Ok();
            }catch (Exception ex) { throw ex; }
        }
    }
}
