using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.Authorization.Models
{
    public class AuthModel
    {
        public string Message { get; set; }
        public List<string> Roles { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }

        
    }
}
