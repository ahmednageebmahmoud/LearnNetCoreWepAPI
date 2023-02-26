using LearnNetCoreWepAPI.Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.Authorization.Helpers.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> Register(RegisterModel register);
        Task<AuthModel> Login(LoginModel login);
    }
}
