using MauiCRUD.Models;
using SQLite;

namespace MauiCRUD.Repositories
{
    public class UserRepository : IUserRepository
    {
        private string dbName = "users.db3";
        private SQLiteAsyncConnection con;
        
        public async Task Init()
        {
            if (con != null)
                return;

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), dbName);

            con = new SQLiteAsyncConnection(dbPath);
            await con.CreateTableAsync<Users>();
        }
        public async Task<List<Users>> GetAllUser()
        {
            await Init();
            try
            {
                return await con.Table<Users>().ToListAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Users> GetById(int id)
        {
            await Init();
            try
            {
                return await con.Table<Users>().ElementAtAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task AddUser(Users user)
        {
            await Init();
            try
            {
                await con.InsertAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUser(Users user)
        {
            await Init();
            try
            {
                await con.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteUser(Users user)
        {
            await Init();
            try
            {
                await con.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
