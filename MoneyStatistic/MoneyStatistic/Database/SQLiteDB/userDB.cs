using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;

namespace MoneyStatistic.Database.SQLiteDB
{
    public class userDB
    {
        private SQLiteAsyncConnection Database;

        public userDB()
        {
            SetUpDb();
        }

        private async void SetUpDb()
        {
            if (Database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MoneyDB.db3");
                Database = new SQLiteAsyncConnection(dbPath);
                await Database.CreateTableAsync<UserLoginStatus>();
            }
        }
        public async Task<int> addItem(UserLoginStatus item)
        {
            return await Database.InsertAsync(item);
        }

        public async Task<List<UserLoginStatus>> GetItemsAsync()
        {
            return await Database.Table<UserLoginStatus>().ToListAsync();
        }

        public async Task<UserLoginStatus> GetFirstItemAsync()
        {
            return await Database.Table<UserLoginStatus>().FirstOrDefaultAsync();
        }

        public async Task<UserLoginStatus> GetItemAsync(int id)
        {
            return await Database.Table<UserLoginStatus>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(UserLoginStatus item)
        {
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(UserLoginStatus item)
        {
            return await Database.DeleteAsync(item);
        }
    }
}
