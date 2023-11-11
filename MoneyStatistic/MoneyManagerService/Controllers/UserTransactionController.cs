using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.EF.JSON;
using Models.EF.MoneyManagerService;

using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoneyManagerService.Controllers
{
    
    [Route("transaction/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class UserTransactionController : ControllerBase
    {
        
         
        private MoneyManagerContext db;
        public UserTransactionController(MoneyManagerContext database) {
            db = database;
        }
         

        // GET: api/<UserTransactionController>
        [HttpGet]
        public List<UserTransaction> GetAllTransaction()
        {
            return db.UserTransactions.ToList();
        }

        // GET api/<UserTransactionController>/5
        [HttpGet("{id}")]
        public List<UserTransaction> GetAllTransactionById(decimal id)
        {
            List<UserTransaction> transactions; 
            try
            {
                transactions = db.UserTransactions.Where(item => item.UserId == id && item.Status == true).ToList();
            }catch (Exception ex)
            {
                transactions = null;
            }

            return transactions;
        }

        // GET api/<UserTransactionController>/expense/5
        [HttpGet("expense/{id}")]
        public List<UserTransaction> GetAllExpenseTransactionById(decimal id)
        {
            List<UserTransaction> transactions;
            try
            {
                transactions = db.UserTransactions.Where(item => item.UserId == id && item.TransType.Equals("expense") && item.Status == true).ToList();
            }
            catch (Exception ex)
            {
                transactions = null;
            }

            return transactions;
        }

        // GET api/<UserTransactionController>/income/5
        [HttpGet("income/{id}")]
        public List<UserTransaction> GetAllIncomeTransactionById(decimal id)
        {
            List<UserTransaction> transactions;
            try
            {
                transactions = db.UserTransactions.Where(item => item.UserId == id && item.TransType.Equals("income") && item.Status == true).ToList();
            }
            catch (Exception ex)
            {
                transactions = null;
            }

            return transactions;
        }


        // POST api/<UserTransactionController>
        [HttpPost]
        public Result AddTransaction([FromBody] UserTransactionBody value)
        {
            if (value == null)
            {
                return new Result{ status = 404,message = "Invalid data",result="failed" };
            }

            try
            {
                db.UserTransactions.Add(new UserTransaction
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
            catch (Exception ex)
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
        public Result Delete(int id)
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
