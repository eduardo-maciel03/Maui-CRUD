using MauiCRUD.Models;

namespace MauiCRUD.Repositories
{
    public interface IUserRepository
    {
        Task Init();
        Task<List<Users>> GetAllUser();
        Task<Users> GetById(int id);
        Task AddUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(Users user);

    }
}
