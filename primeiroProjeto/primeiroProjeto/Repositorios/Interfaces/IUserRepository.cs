using Microsoft.AspNetCore.Components.Web;
using primeiroProjeto.Models;

namespace primeiroProjeto.Repositorios.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UsersModel>> GetAllUsers();
        Task<UsersModel> GetUserById(int Id);
        Task<UsersModel> AddUser(UsersModel User);
        Task<UsersModel> UpdateUser(UsersModel User, int Id);
        Task<bool> DeleteUser(int Id);
    }
}
