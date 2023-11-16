using DWAApi.Data;
using DWAApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using System.Security.Claims;

namespace DWAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly UserContext _userContext;
        public UserInfoController(UserContext userContext)
        {
            _userContext = userContext;
        }
        [HttpGet]
        [Route("getAll")]
        public JsonResult GetUserInfo()
        {
            try
            {
                
                List<UserInfo> userInList = _userContext.UserInfos.ToList();
                if (userInList != null && userInList.Count > 0)
                {
                    return new JsonResult(userInList);
                }
                return new JsonResult(NoContent());
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return new JsonResult(BadRequest());
            }
        }

        [HttpPost]
        [Route("createData")]
        public JsonResult CreateUserInfo([FromBody] UserInfo userInBody) 
        {
            try
            {
        /*        User? user = _userContext.Users.FirstOrDefault(p => userInBody.Id == p.UserInfoId);

                UserInfo? usIn = _userContext.UserInfos.FirstOrDefault(p => userInBody == p);
                Console.WriteLine(usIn);
                if(usIn != null)
                {
                    _userContext.UserInfos.Add(userInBody);
                    _userContext.SaveChanges();
                }
                else
                {
                    userInBody.Id = usIn.Id;
                }
                userInBody.User = user;
                _userContext.SaveChanges();
                return new JsonResult("UserInfo created\n"+userInBody);*/
               UserInfo? userInfo = _userContext.UserInfos.FirstOrDefault(p =>
                    p.Age == userInBody.Age &&
                    p.SkinColour == userInBody.SkinColour &&
                    p.EUSizeS == userInBody.EUSizeS &&
                    p.EUSizeT == userInBody.EUSizeT &&
                    p.EUSizeL == userInBody.EUSizeL &&
                    p.CircleHip == userInBody.CircleHip &&
                    p.CircleChest == userInBody.CircleChest &&
                    p.CircleCalf == userInBody.CircleCalf 
                    );
                                                        
                if (userInfo == null) 
                {
                    Console.WriteLine(userInBody.Id);
                    userInBody.Id = Guid.NewGuid();
                    _userContext.UserInfos.Add(userInBody);
                    Console.WriteLine(userInBody.Id);
                    _userContext.SaveChanges();
                    //return new JsonResult(userInfo);
                }

                return new JsonResult(NoContent());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new JsonResult(BadRequest());
            }
        }
        [HttpPost]
        [Route("selectData")]
        public JsonResult SelectUserInfo(string userName,[FromBody] UserInfo userInfo) 
        {
            try
            {
                User? user = _userContext.Users.FirstOrDefault(p => p.Login == userName);
                if(user == null)
                {
                    return new JsonResult(BadRequest("No user with this login"));
                }
                UserInfo? usIn = _userContext.UserInfos.FirstOrDefault(p => p == userInfo);
                if(usIn != null)
                {
                    usIn.User = user;
                    user.UserInfoId = usIn.Id;
                    _userContext.SaveChanges();
                    return new JsonResult(user);
                }
                _userContext.UserInfos.Add(userInfo);
                userInfo.User = user; 
                user.UserInfoId=userInfo.Id;
                _userContext.SaveChanges();
                return new JsonResult(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new JsonResult(BadRequest());
            }
        }
        [HttpPut]
        [Route("updateData")]
        public JsonResult UpdateUserInfo([FromBody]UserInfo userInfo) 
        {
            try
            {
                UserInfo? usIn = _userContext.UserInfos.FirstOrDefault(p => p.Id == userInfo.Id);
                usIn = userInfo;
               
                _userContext.SaveChanges();
                return new JsonResult("Updated successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new JsonResult(BadRequest());    
            }
        }
    }
    
}
