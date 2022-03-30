using aljuvifoods_webapi.DTOs.Login;
using aljuvifoods_webapi.DTOs.User;
using aljuvifoods_webapi.Models;
using aljuvifoods_webapi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aljuvifoods_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AuthController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginDTO>> UserLogin(LoginCDTO login)
        {
            var user = await context.Users.Include(x=>x.UserRole).FirstOrDefaultAsync(u => u.Email == login.Email);
            if(user == null)
                return NotFound();
            var isValidPassword = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
            if (isValidPassword)
                return Ok( new LoginDTO() { isLogged = true, Role = user.UserRole.Description,UserId=user.UserId });

            else
            return BadRequest("Password is not valid");
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginDTO>> CreateNewUser(UserCDTO user)
        {
            var userExists = await context.Users.AnyAsync(u => u.Email == user.Email);
            if (userExists)
                return BadRequest("User already exists");
            var userCDTO = mapper.Map<User>(user);
            
            userCDTO.RoleId = 2;
            userCDTO.Password = BCrypt.Net.BCrypt.HashPassword(userCDTO.Password);
            context.Users.Add(userCDTO);
            await context.SaveChangesAsync();
            var newUser = await context.Users.Include(u=>u.UserRole).FirstOrDefaultAsync(u=>u.Email==user.Email);
            return Ok(new LoginDTO() { isLogged = true, Role = newUser.UserRole.Description, UserId = newUser.UserId });
        }
    }
}
