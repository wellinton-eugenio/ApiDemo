using Microsoft.EntityFrameworkCore;
using primeiroProjeto.Data;
using primeiroProjeto.Models;
using primeiroProjeto.Repositorios.Interfaces;

namespace primeiroProjeto.Repositorios
{
    public class UserRepository : IUserRepository
    {
        private readonly ToDoSystemDbContext _dbContext;
        public UserRepository(ToDoSystemDbContext ToDoSystemDbContext)
        {
            _dbContext = ToDoSystemDbContext;
        }

        public async Task<List<UsersModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UsersModel> GetUserById(int Id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<UsersModel> AddUser(UsersModel User)
        {
            await _dbContext.Users.AddAsync(User);
            await _dbContext.SaveChangesAsync();

            return User;
        }

        public async Task<UsersModel> UpdateUser(UsersModel User, int Id)
        {
            UsersModel UserByid = await GetUserById(Id);

            if(UserByid == null)
            {
                throw new Exception($"Usuario com o id: {Id} não encontrado");
            }

            UserByid.Name = User.Name;
            UserByid.Email = User.Email;
            UserByid.Password = User.Password;

            _dbContext.Users.Update(UserByid);
            await _dbContext.SaveChangesAsync();

            return UserByid;

        }

        public async Task<bool> DeleteUser(int Id)
        {
            UsersModel UserByid = await GetUserById(Id);

            if (UserByid == null)
            {
                throw new Exception($"Usuario com o id: {Id} não encontrado");
            }

            _dbContext.Users.Remove(UserByid);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }
}
