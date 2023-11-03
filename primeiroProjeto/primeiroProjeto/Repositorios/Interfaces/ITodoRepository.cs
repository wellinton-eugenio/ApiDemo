using Microsoft.AspNetCore.Components.Web;
using primeiroProjeto.Models;

namespace primeiroProjeto.Repositorios.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<ToDoModel>> GetAllToDo();
        Task<ToDoModel> GetToDoById(int Id);
        Task<ToDoModel> AddToDo(ToDoModel ToDo);
        Task<ToDoModel> UpdateToDo(ToDoModel toDo, int Id);
        Task<bool> DeleteToDo(int Id);
    }
}
