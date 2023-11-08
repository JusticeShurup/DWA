using DWAApi.Data;
using DWAApi.Models;
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
                User? us = _userContext.Users.FirstOrDefault(p => p.Login == user.Login);
                //Console.WriteLine("\nus.Login=" + us.Login+"\n");
                if(us != null) 
                {
                    return new JsonResult(BadRequest("This nickname already exists. Please choose another"));
                }
                Console.WriteLine(user.Id);
                
                _userContext.Users.Add(user);
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                Console.WriteLine(user.Password);
                _userContext.SaveChanges();
            }
            catch (Exception ex)
            {
    
                //if (ex.GetType() == typeof(Exce) )
                Console.WriteLine(ex.ToString());
               // return new JsonResult(BadRequest(ex.ToString()));
            }

            return new JsonResult(Ok("User created"));

        }

        [HttpGet]
        [Route("TryToLogin")]
        public JsonResult TryLogin(string login, string password)
        {
            bool result = false;
            try
            {
                User? user = _userContext.Users.FirstOrDefault(p => p.Login == login);

                if (user == null)
                {
                    return new JsonResult(BadRequest("User doesn't exist"));
                }

                string hashedPassword = user.Password;

                result = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

                if (result)
                {
                    return new JsonResult(Ok(result));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new JsonResult(Unauthorized(result));
        }

        [HttpDelete]
        [Route("DeleteSmth")]
        public JsonResult Delete(Guid id)
        {
            try
            {
                User? user = _userContext.Users.FirstOrDefault(p => p.Id == id);
                if (user == null)
                {
                    return new JsonResult(BadRequest("User with this id doesn't exist"));
                }
                _userContext.Users.Remove(user);
                _userContext.SaveChanges();
            }
            catch (Exception ex) 
            {
               Console.WriteLine(ex.ToString());
            }
            return new JsonResult(Ok("User deleted"));
        }

        [HttpPut]
        [Route("UpdateSmth")]
        //app.MapPut("/api/users", (Person userData) =>
        public JsonResult Update(User user)
        {
            try
            {
                // получаем пользователя по id
                User? us = _userContext.Users.FirstOrDefault(u => u.Id == user.Id);
                // если не найден, отправляем статусный код и сообщение об ошибке
                if (us == null)
                {
                    return new JsonResult(BadRequest("User with this id doesn't exist"));
                }
                // если пользователь найден, изменяем его данные и отправляем обратно клиенту

                us.Login = user.Login;
                us.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _userContext.SaveChanges();
                return new JsonResult(us);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new JsonResult(BadRequest("You got exception: "+ex.GetType()));
            }
        }   
    }
}
