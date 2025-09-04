using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;
using MyFirstAPI.Services;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }


        [HttpGet]
        [ProducesResponseType(typeof(TaskModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllFromList()
        {
        
            var Users = _userServices.GetAllTasks();

            return Ok(Users);
           
        
        }

        [HttpGet]
        [Route("Ge")]
        public IActionResult GetbyId(int id)
        { 
            var response = _userServices.SearchTaskbyID(id);
            
            if (response == null)
            {
                return BadRequest($"O id não foi encontrado: {id}");
            }

            return Ok(response);
        
        }


        [HttpPost]
        public IActionResult AdicionarUsers(string name, string descrition, string finishDate, string status, int priority)
        {

            _userServices.addTaskToList(name, descrition, finishDate, status, priority);
            return Ok($"Task '{name}' foi adicionado ao grupo!");
        
        }

        [HttpDelete]
        public IActionResult DeleteUserFromList(int id)
        {
        
            _userServices.removeTaskOfList(id);
            return Ok($"Task com ID: '{id}' removido da lista.");
        
        }

    }
}
