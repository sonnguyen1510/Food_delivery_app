using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.EF.JSON;
using Models.EF.MoneyManagerService;
using Models.EF;
using Azure.Identity;

namespace MoneyManagerService.Controllers
{
    [Route("Login/[Action]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private MoneyManagerContext db;
        public LoginController(MoneyManagerContext database)
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
