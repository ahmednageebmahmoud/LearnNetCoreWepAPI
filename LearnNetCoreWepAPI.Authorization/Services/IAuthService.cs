using LearnNetCoreWepAPI.Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.BLL.Services
{
    public interface IAuthService
    {
        Task<AuthModel> Register(RegisterModel register);
    }
}
