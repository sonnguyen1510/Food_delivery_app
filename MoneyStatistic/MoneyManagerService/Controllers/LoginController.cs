using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.EF.JSON;
using Models.EF.MoneyManagerService;
using Models.EF;
using Azure.Identity;
using MoneyManagerService.EF.MoneyManagerService;

namespace MoneyManagerService.Controllers
{
    [Route("Login/[Action]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private DbAa1f83MoneymanagerContext db;
        public LoginController(DbAa1f83MoneymanagerContext database)
        {
            db = database;
        }

        [HttpGet]
        public User LoginCheck([FromQuery] string Username, [FromQuery] string password)
        {
            return db.Users.Where(item=>item.Username == Username && item.Password == password).FirstOrDefault();
            
        }
    }
}
