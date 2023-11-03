using Microsoft.EntityFrameworkCore;
using primeiroProjeto.Data;
using primeiroProjeto.Models;
using primeiroProjeto.Repositorios.Interfaces;

namespace primeiroProjeto.Repositorios
{
    public class ToDoRepository : ITodoRepository
    {
        private readonly ToDoSystemDbContext _dbContext;
        public ToDoRepository(ToDoSystemDbContext ToDoSystemDbContext)
        {
            _dbContext = ToDoSystemDbContext;
        }

        public async Task<List<ToDoModel>> GetAllToDo()
        {
            return await _dbContext.ToDo
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<ToDoModel> GetToDoById(int Id)
        {
            return await _dbContext.ToDo
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<ToDoModel> AddToDo(ToDoModel ToDo)
        {
            await _dbContext.ToDo.AddAsync(ToDo);
            await _dbContext.SaveChangesAsync();

            return ToDo;
        }

        public async Task<ToDoModel> UpdateToDo(ToDoModel ToDo, int Id)
        {
            ToDoModel ToDoByid = await GetToDoById(Id);

            if (ToDoByid == null)
            {
                throw new Exception($"tarefa com o id: {Id} não encontrada!");
            }

            ToDoByid.Name = ToDo.Name;
            ToDoByid.Description = ToDo.Description;
            ToDoByid.Status = ToDo.Status;
            ToDoByid.UserId = ToDo.UserId;

            _dbContext.ToDo.Update(ToDoByid);
            await _dbContext.SaveChangesAsync();

            return ToDoByid;

        }

        public async Task<bool> DeleteToDo(int Id)
        {
            ToDoModel ToDoById = await GetToDoById(Id);

            if (ToDoById == null)
            {
                throw new Exception($"tarefa com o id: {Id} não encontrada!");
            }

            _dbContext.ToDo.Remove(ToDoById);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }
}