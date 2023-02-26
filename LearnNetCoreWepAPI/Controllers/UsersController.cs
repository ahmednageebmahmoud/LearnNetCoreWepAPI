using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnNetCoreWepAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class UsersController : Controller
    {
        [HttpGet("list")]
        public async Task<IActionResult> ListOfEmployees()
        {

            return Ok("Authrize Is Working");
        }

        [Authorize(Roles ="Admin")]

        [HttpGet("adminList")]
        public async Task<IActionResult> ListOfEmployeesForAdmin()
        {

            return Ok("Authrize Is Working");
        }
    }
}
