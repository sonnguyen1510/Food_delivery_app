using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.EF.JSON;
using Models.EF.MoneyManagerService;
using MoneyManagerService.EF.MoneyManagerService;

namespace MoneyManagerService.Controllers
{
    [Route("user/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
         private DbAa1f83MoneymanagerContext db;
         public UserController(DbAa1f83MoneymanagerContext database)
         {
             db= database;
         }

         [HttpGet("{id}")]
         public User getUserById(String id)
         {
             User user;
            try
            {
                user = db.Users.Where(item=>item.Id.Equals( id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                user = null;
            }

            return user;
        }

        [HttpGet("{Username}")]
        public User getUserByUserame(String Username) {
            User user;
            try
            {
                user = db.Users.Where(item => item.Username.Equals(Username)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                user = null;
            }

            return user;
        }

        [HttpPost]
        public Result addUser([FromBody] UserBody value)
        {
            if (value == null)
            {
                return new Result { status = 404, message = "Invalid data", result = "failed" };
            }

            try
            {
                db.Users.Add(new User
                {
                    Username = value.Username,
                    Password = value.Password,
                    Email = value.Email,
                    Fullname = value.Fullname,
                    Phone = value.Phone,
                    Status = value.Status,
                });
                db.SaveChanges();
                return new Result { status = 202, message = "Add transaction success", result = "success" };
            }
            catch (Exception)
            {
                return new Result { status = 404, message = "Add transaction fail", result = "failed" };
            }
        }
         
    }
}
