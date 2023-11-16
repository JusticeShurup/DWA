using DWAApi.Data;
using DWAApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static WBAAPI.Program;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;

namespace DWAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;
        private readonly IConfiguration _configuration;

        public UserController(UserContext userContext, IConfiguration configuration)
        {
            _userContext = userContext;
            _configuration = configuration;
        }
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
            
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

        [HttpGet]
        [Route("getId/{id}")]
        public JsonResult GetById(Guid id)
        {
            try
            {

                User? user = _userContext.Users.FirstOrDefault(p => p.Id == id);
                if (user == null)
                {
                    return new JsonResult(BadRequest("User doesn't exist"));
                }
                return new JsonResult(Ok(true));
            }
            catch (Exception ex) 
            {
                Console.Write(ex.ToString());   
                return new JsonResult(BadRequest());    
            }

        }
        [HttpGet]
        [Route("getAll")]
        public JsonResult GetAll()
        {
            try
            {
                List<User> UList = _userContext.Users.ToList();
                return new JsonResult(UList);

            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString);
                return new JsonResult(BadRequest());
            }
        }
        [HttpPost]
        [Route("registry")]
        public JsonResult RegistryUser([FromBody] User user)
        {
            try
            {
                User? us = _userContext.Users.FirstOrDefault(p => p.Login == user.Login);
                //Console.WriteLine("\nus.Login=" + us.Login+"\n");
                //UserInfo? usIn = _userContext.UserInfos.FirstOrDefault(p => p.Id.Equals(user.UserInfoId));
                if (us != null)
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
                Console.WriteLine(ex.ToString());
                return new JsonResult("Unexpected exception");
            }

            return new JsonResult(Ok("User created"));
            //состояние, токен(access and refresh)
        }


        [HttpPost]
        [Route("login")]
        public JsonResult TryLogin(string login, string password)
        {
            try
            {
                User? user = _userContext.Users.FirstOrDefault(p => (p.Login == login));
                if (user is null) return new JsonResult(Results.Unauthorized());
                if (!BCrypt.Net.BCrypt.Verify(password, user.Password)) return new JsonResult(Results.Unauthorized());
                List<Claim> claims = new List<Claim> 
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())                             
                };
                JwtSecurityToken jwt = CreateToken(claims);
                TokenModel tokenModel = new TokenModel()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
                    RefreshToken = GenerateRefreshToken(),
                    Expiration = jwt.ValidTo
                };
                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
                user.RefreshToken = tokenModel.RefreshToken;      
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
                _userContext.SaveChanges();

                return  new JsonResult(tokenModel); //accessToken+refreshToken+expirationDate
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new JsonResult(BadRequest());
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
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
        [Route("update")]
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
                return new JsonResult("User " + us.Login + "deleted");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new JsonResult(BadRequest("You got exception: "+ex.GetType()));
            }
        }   
    }
}