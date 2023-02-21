using LearnNetCoreWepAPI.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.DAL.models
{
    public class Media
    {
        public int Id { get; set; }
        public string FileURL { get; set; }
        public int EmpoId { get; set; }
        public Employee  Employee{ get; set; }
    }
}
