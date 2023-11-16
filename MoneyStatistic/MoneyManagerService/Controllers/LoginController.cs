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
        public decimal LoginCheck([FromQuery] string Username, [FromQuery] string password)
        {
            User user = db.Users.Where(item=>item.Username == Username && item.Password == password).FirstOrDefault();
            if (user == null)
            {
                return -1;
            }
            else
                return user.Id;
        }
    }
}
