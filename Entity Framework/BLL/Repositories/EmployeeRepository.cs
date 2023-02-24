using LearnNetCoreWepAPI.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.BLL.Repositories
{

    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
