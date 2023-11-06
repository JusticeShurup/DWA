using DWAApi.Data;
using DWAApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DWAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpPost]
        [Route("RegistryUser")]
        public JsonResult RegistryUser([FromBody] User user)
        {
            try
            {
                Console.WriteLine(user.Id);
                _userContext.Users.Add(user);
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                Console.WriteLine(user.Password);
                _userContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return new JsonResult(Ok("User created"));

        }

        [HttpGet]
        [Route("TryLogin")]
        public JsonResult TryLogin(string login, string password)
        {
            bool result = false;
            try
            {
                User? user = _userContext.Users.FirstOrDefault(p => p.Login == login);

                if (user == null)
                {
                    return new JsonResult(BadRequest("User isn't exists"));
                }

                string hashedPassword = user.Password;

                result = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

                if (result);
                {
                    return new JsonResult(Ok(result));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return new JsonResult(Unauthorized(result));
        }

    }
}
