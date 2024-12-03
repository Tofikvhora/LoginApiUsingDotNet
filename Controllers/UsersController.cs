using LoginApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public UsersController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("Registration")]

        public IActionResult Registration(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objUser = dbContext.Users.FirstOrDefault(x => x.Email == userDTO.Email);
            if (objUser == null)
            {
                dbContext.Users.Add(new Users
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Email = userDTO.Email,
                    Password = userDTO.Password,
                });
                dbContext.SaveChanges();
                return Ok("User Registered Successfully");
            }
            else
            {
                return BadRequest("User already Exists with same email");
            }
        }

        [HttpPost][Route("Login")]
        public IActionResult Login(LoginDTO logindto)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Email == logindto.Email && x.Password == logindto.Password);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet][Route("GetUsers")]
         public IActionResult GetUsers()
        {
            return Ok(dbContext.Users.ToList());
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(int id)
        {
            var user = dbContext.Users.FirstOrDefault(x=> x.UserId == id);

            if (user != null)
            {
                return Ok(user);

            }
            return NoContent();
            
        }
    }
}
