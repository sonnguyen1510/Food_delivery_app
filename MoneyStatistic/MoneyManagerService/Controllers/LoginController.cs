using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.EF.JSON;
using Models.EF.MoneyManagerService;
using Models.EF;

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
        public decimal LoginCheck([FromBody] LoginBody value)
        {
            User user = db.Users.Where(item=>item.Username == value.Username && item.Password == value.Password).FirstOrDefault();
            if (user == null)
            {
                return -1;
            }
            else
                return user.Id;
        }
    }
}
