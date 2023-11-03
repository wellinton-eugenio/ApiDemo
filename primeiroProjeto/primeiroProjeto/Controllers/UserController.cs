using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using primeiroProjeto.Models;
using primeiroProjeto.Repositorios.Interfaces;

namespace primeiroProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsersModel>>> GetAllUsers() 
        {
            List<UsersModel> Users = await _userRepository.GetAllUsers();
            return Ok(Users);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<UsersModel>>> GetUserById(int Id)
        {
            UsersModel User = await _userRepository.GetUserById(Id);
            return Ok(User);
        }

        [HttpPost]
        public async Task<ActionResult<List<UsersModel>>> AddUser([FromBody] UsersModel User)
        {
            await _userRepository.AddUser(User);
            return Ok(User);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<List<UsersModel>>> UpdateUser([FromBody] UsersModel User, int Id)
        {
            User.Id = Id;
            UsersModel user =  await _userRepository.UpdateUser(User, Id);
            return Ok(user);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<UsersModel>>> DeleteUser(int Id)
        {
            bool deleted = await _userRepository.DeleteUser(Id);
            return Ok(deleted);
        }
    }
}
