using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Azure.Identity;
using MoneyManagerServer.EF.MoneyManagerService;

namespace MoneyManagerServer.Controllers
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
