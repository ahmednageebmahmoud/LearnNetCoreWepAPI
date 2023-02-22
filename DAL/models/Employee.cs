using LearnNetCoreWepAPI.DAL.models;
using System.ComponentModel.DataAnnotations;

namespace LearnNetCoreWepAPI.models
{
    public class Employee
    {
        public int Id { get; set; }
        public int UserRegisterNO { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

      public List<Post> Posts{ get; set; }
      public Media Media { get; set; }
        


    }
}
