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
            this._Entity = entity;
        }

        [HttpPost(Name ="Add")]
        public async Task<string> AddEmployee([FromBody] EployeeDTO emp)
        {
           await this._Entity.Add(new Employee{Name=emp.Name});
        var IsDone=await    this._Entity.Save();
            return IsDone?"Addedd Successfully":"Some Error Has Been";
        
        }

        [HttpGet]
        public async Task<Employee> FindEmployee()
        {
           var Emp= this._Entity._entities.FirstOrDefault();
            return Emp;
        }
    }
}
