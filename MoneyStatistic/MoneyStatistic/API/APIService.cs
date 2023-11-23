using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using MoneyStatistic.Database.MoneyManagerService;
using MoneyStatistic.Database.JSON;

namespace MoneyStatistic.API
{

    public class APIService
    {
        private static int PORT = 5050;
        private static string HOST = "172.16.3.32";


        private static HttpClient client = new HttpClient();

        public static async Task<List<UserTransaction>> getTransactionByRange(string StartDay , string EndDay){
            // Define the API endpoint URL
                string apiUrl = "http://" + HOST + $":{PORT}/transaction/GetTransactionByRangeofDay?StartDay={StartDay}&EndDay={EndDay}";

                // Send an HTTP GET request to the API
                return await client.GetFromJsonAsync<List<UserTransaction>>(apiUrl);
        }

        public static async Task<List<UserTransaction>> getTransactionByRange(string StartDay, string EndDay , decimal Userid)
        {
            // Define the API endpoint URL
            string apiUrl = "http://" + HOST + $":{PORT}/transaction/GetTransactionByRangeofDay/{Userid}?StartDay={StartDay}&EndDay={EndDay}";

            // Send an HTTP GET request to the API
            return await client.GetFromJsonAsync<List<UserTransaction>>(apiUrl);
        }

        public static async Task<List<UserTransaction>> getTransactionByYear(string year)
        {
            // Define the API endpoint URL
            string apiUrl = "http://" + HOST + $":{PORT}/transaction/getTransactionByYear?year={year}";

            // Send an HTTP GET request to the API
            return await client.GetFromJsonAsync<List<UserTransaction>>(apiUrl);
        }

        public static async Task<List<UserTransaction>> getTransactionByYear(string year , decimal userid)
        {
            // Define the API endpoint URL
            string apiUrl = "http://" + HOST + $":{PORT}/transaction/getTransactionByYear/{userid}?year={year}";

            // Send an HTTP GET request to the API
            return await client.GetFromJsonAsync<List<UserTransaction>>(apiUrl);
        }

        public static async Task<List<UserTransaction>> getAllTransaction()
        {
            // Define the API endpoint URL
            var apiUrl = "http://" + HOST + $":{PORT}/transaction/GetAllTransaction";

            // Send an HTTP GET request to the API
            return await client.GetFromJsonAsync<List<UserTransaction>>(apiUrl);

        }

        public static async Task<HttpResponseMessage> DeleteTransactionAsync(UserTransaction transaction) {
            // Define the API endpoint URL
            var apiUrl = "http://" + HOST + $":{PORT}/transaction/Delete/{transaction.Id}";

            // Post data to the server
            return await client.DeleteAsync(apiUrl);
        }

        public static async Task<HttpResponseMessage> AddUserTransaction(UserTransactionBody data)
        {
            return await client.PostAsJsonAsync<UserTransactionBody>("http://" + HOST + $":{PORT}/transaction/AddTransaction", data);
        } 

        public static async Task<User> Login(string username, string password)
        {
            // Define the API endpoint URL
            var apiUrl = "http://" + HOST + $":{PORT}/Login/LoginCheck?Username={username}&password={password}";

            User user = await client.GetFromJsonAsync<User>(apiUrl);
            if(user == null)
            {
                return new User { Id = -1};
            }
            else
            {
                return user;
            }
            
            // Send an HTTP GET request to the API
           
        }
    }
}
