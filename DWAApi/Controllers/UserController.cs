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
                _userContext.Users.Add(user);
                _userContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return new JsonResult(Ok("User created"));

        }

        [HttpGet]
        public JsonResult HelloWorld()
        {
            return new JsonResult(Ok("Hello World"));
        }

        [HttpGet]
        [Route("GoodByeWorld")]
        public JsonResult GoodByeWorld()
        {
            return new JsonResult(Ok("Goodbye World"));
        }
    }
}
