using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Data;
using RealEstate.Model;
using System.Text;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly AppDataContext _context;
        private IConfiguration _configuration; //to access jwt from appsetting
        public UserController(AppDataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("[Action]")]
        public IActionResult Register([FromBody] User user)
        {
            var userExist=_context.Users.FirstOrDefault(x=>x.Email== user.Email);
            if(userExist!=null)
            {
                return BadRequest("User with this email address is already registered");

            }
            _context.Users.Add(user);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost("[Action]")]
        public IActionResult Login([FromBody] User user)
        {
            var CurrentUser = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password==user.Password);
            if (CurrentUser != null)
            {
                return NotFound();

            }
          var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JET:Key"]));  //key to encrypt or decrypt data


        }

    }
}
