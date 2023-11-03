using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using primeiroProjeto.Models;
using primeiroProjeto.Repositorios.Interfaces;

namespace primeiroProjeto.Controllers
{
    [Route("api/ToDo")]
    [ApiController]
    public class ToDoControler : ControllerBase
    {
        private readonly  ITodoRepository _todoRepository;

        public ToDoControler(ITodoRepository  ToDoRepository)
        {
            _todoRepository = ToDoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<ToDoModel>>> GetAllToDo() 
        {
            List<ToDoModel> ToDos = await _todoRepository.GetAllToDo();
            return Ok(ToDos);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<ToDoModel>>> GetUserById(int Id)
        {
            ToDoModel Todo = await _todoRepository.GetToDoById(Id);
            return Ok(Todo);
        }

        [HttpPost]
        public async Task<ActionResult<List<ToDoModel>>> AddToDo([FromBody] ToDoModel ToDo)
        {
            await _todoRepository.AddToDo(ToDo);
            return Ok(ToDo);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<List<ToDoModel>>> UpdateToDo([FromBody] ToDoModel ToDo, int Id)
        {
            ToDo.Id = Id;
            ToDoModel toDo = await _todoRepository.UpdateToDo(ToDo, Id);
            return Ok(toDo);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<ToDoModel>>> DeleteToDO(int Id)
        {
            bool deleted = await _todoRepository.DeleteToDo(Id);
            return Ok(deleted);
        }
    }
}