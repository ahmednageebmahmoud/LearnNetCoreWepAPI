using LearnNetCoreWepAPI.BLL.Helpers;
using LearnNetCoreWepAPI.BLL.Helpers;
using LearnNetCoreWepAPI.BLL.Repositories;
using LearnNetCoreWepAPI.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnNetCoreWepAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public IRepository<Employee> _Entity;
        public EmployeeController(IRepository<Employee> entity)
        {
            db = entity;
        }

        [HttpPost(Name ="Add")]
        public async Task<string> AddEmployee([FromBody] EployeeDTO emp)
        {
            return false?"Addedd Successfully":"Some Error Has Been";
        
        }

        [HttpGet]
        public async Task<Employee> FindEmployee()
        {
            db.Users.Find(who); 
            db.Entry(user)
                    .Collection(u => u.Connections)
                    .Query()
                    .Where(c => c.Connected == true)
                    .Load();


            db._entities.MinBy(c => c.Age);

            return null;
        }
    }
}
