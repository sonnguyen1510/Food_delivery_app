
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyManagerServer.EF.MoneyManagerService;
using System.Collections.Generic;
using MoneyManagerServer.EF.JSON;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoneyManagerService.Controllers
{

    [Route("transaction/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class UserTransactionController : ControllerBase
    {


        private DbAa1f83MoneymanagerContext db;
        public UserTransactionController(DbAa1f83MoneymanagerContext database) {
            db = database;
        }


        // GET: api/<UserTransactionController>
        [HttpGet]
        public async Task<List<UserTransaction>> GetAllTransaction()
        {
            return await db.UserTransactions.Where(item => item.Status == true).ToListAsync();
        }
        // GET: api/<UserTransactionController>
        [HttpGet]
        public async Task<List<UserTransaction>> GetTransactionByRangeofDay([FromQuery] string StartDay, [FromQuery] string EndDay)
        {            
            String[] Start = StartDay.Split("-");
            String[] End = EndDay.Split("-");
            return await db.UserTransactions.Where(item => item.Status == true && item.CreDate.Value.Year == int.Parse(Start[2]) && item.CreDate.Value.Month == int.Parse(Start[1]) && (item.CreDate.Value.Day > int.Parse(Start[0]) && item.CreDate.Value.Day < int.Parse(End[0]))).ToListAsync();
        }            
                     
        [HttpGet]    
        public async Task<List<UserTransaction>> getTransactionByYear([FromQuery] string year)
        {
            return await db.UserTransactions.Where(item => (item.CreDate.Value.Year.ToString().Equals(year)) && item.Status == true).ToListAsync();
        }

        [HttpGet("{userid}")]
        public async Task<List<UserTransaction>> getTransactionByYear([FromQuery] string year,int userid)
        {
            return await db.UserTransactions.Where(item => (item.CreDate.Value.Year.ToString().Equals(year)) &&item.UserId == userid && item.Status == true).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<List<UserTransaction>> GetTransactionByRangeofDay([FromQuery] string StartDay, [FromQuery] string EndDay, int id)
        {
            String[] Start = StartDay.Split("-");
            String[] End = EndDay.Split("-");
            return await db.UserTransactions.Where(item => item.UserId==id && item.Status == true && item.CreDate.Value.Year == int.Parse(Start[2]) && item.CreDate.Value.Month == int.Parse(Start[1]) && (item.CreDate.Value.Day > int.Parse(Start[0]) && item.CreDate.Value.Day < int.Parse(End[0]))).ToListAsync();
        }



        // GET api/<UserTransactionController>/5
        [HttpGet("{id}")]
        public async Task<List<UserTransaction>> GetAllTransactionById(decimal id)
        {
            List<UserTransaction> transactions; 
            try
            {
                transactions = await db.UserTransactions.Where(item => item.UserId == id && item.Status == true).ToListAsync();
            }catch (Exception ex)
            {
                transactions = null;
            }

            return transactions;
        }

        // GET api/<UserTransactionController>/expense/5
        [HttpGet("expense/{id}")]
        public async Task<List<UserTransaction>> GetAllExpenseTransactionById(decimal id)
        {
            List<UserTransaction> transactions;
            try
            {
                transactions = await db.UserTransactions.Where(item => item.UserId == id && item.TransType.Equals("expense") && item.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                transactions = null;
            }

            return transactions;
        }

        // GET api/<UserTransactionController>/income/5
        [HttpGet("income/{id}")]
        public async Task<List<UserTransaction>> GetAllIncomeTransactionById(decimal id)
        {
            List<UserTransaction> transactions;
            try
            {
                transactions = await db.UserTransactions.Where(item => item.UserId == id && item.TransType.Equals("income") && item.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                transactions = null;
            }

            return transactions;
        }


        // POST api/<UserTransactionController>
        [HttpPost]
        public async Task<Result> AddTransaction([FromBody] UserTransactionBody value)
        {
            if (value == null)
            {
                return new Result{ status = 404,message = "Invalid data",result="failed" };
            }

            try
            {
                await db.UserTransactions.AddAsync(new UserTransaction
                {
                    Title = value.Title,
                    TransType = value.TransType,
                    TransIcon = value.TransIcon,
                    CreTime = TimeSpan.Parse(value.CreTime),
                    CreDate = DateTime.Parse(value.CreDate),
                    Amount = value.Amount,
                    UserId = value.UserId,
                    Status = value.Status
                }); ;
                db.SaveChanges();
                return new Result { status = 202, message = "Add transaction success", result = "success" };
            }
            catch (Exception)
            {
                return new Result { status = 404, message = "Add transaction fail", result = "failed" };
            }
        }

        // PUT api/<UserTransactionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserTransactionController>/5
        [HttpDelete("{id}")]
        public async Task<Result> Delete(int id)
        {
            try
            {
                UserTransaction user = db.UserTransactions.First(item => item.Id == id);
                if(user == null)
                {
                    return new Result { status = 404, message = "Cannot find user", result = "failed" };
                }
                else
                {
                    user.Status = false;
                    db.Entry(user).State = EntityState.Modified;

                    
                    try
                    {
                        db.SaveChanges();
                        return new Result { status = 202, message = "Delete transaction success", result = "success" };
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return new Result { status = 404, message = "Delete transaction fail", result = "failed" };
                    }
                }

            }catch (Exception ex)
            {
                return new Result { status = 404, message = "Delete transaction fail", result = "failed" };
            }
        }
    }
}
