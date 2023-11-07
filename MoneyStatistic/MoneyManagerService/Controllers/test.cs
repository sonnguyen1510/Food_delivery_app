using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyManagerService.EF.MoneyManagerService;

namespace MoneyManagerService.Controllers
{
    [Route("test/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class test : ControllerBase
    {
        private MoneyManagerContext db;
        public test(MoneyManagerContext database)
        {
            db= database;
        }

        [HttpGet]
        public User getrandomuser()
        {
            return db.Users.FirstOrDefault();
        }
    }
}
