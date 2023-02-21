﻿using LearnNetCoreWepAPI.BLL.Repositories;
using LearnNetCoreWepAPI.models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost(Name ="AddEmployee")]
        public async Task<string> AddEmployee([FromBody]Employee emp)
        {
           await this._Entity.Add(emp);
        var IsDone=await    this._Entity.Save();
            return IsDone?"Addedd Successfully":"Some Error Has Been";
        
        }
    }
}