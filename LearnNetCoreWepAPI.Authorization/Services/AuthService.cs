using LearnNetCoreWepAPI.Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LearnNetCoreWepAPI.DAL.models;
using LearnNetCoreWepAPI.DAL.Helpers;

namespace LearnNetCoreWepAPI.BLL.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManger;
        public AuthService(UserManager<ApplicationUser> userManger)
        {
            _userManger = userManger;
        }


        public async Task<AuthModel> Register(RegisterModel register)
        {
            //Check From Email
            if (await this._userManger.FindByEmailAsync(register.Email) is not null)
                return new AuthModel { Message = "Email Is Alredy Used" };

            //Check From UserName
            if (await this._userManger.FindByEmailAsync(register.UserName) is not null)
                return new AuthModel { Message = "UserName Is Alredy Used" };

            var User = new ApplicationUser
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                UserName = register.UserName,
            };

            //Create User
            var Result = await this._userManger.CreateAsync(User, register.Password);

            if (!Result.Succeeded)
                return new AuthModel { Message = String.Join("m", Result.Errors.Select(c => c.Description).ToList()) };

            //Add User Role
            Result = await this._userManger.AddToRoleAsync(User, RoleConsts.UserRole);
            if (!Result.Succeeded)
                return new AuthModel { Message = String.Join("m", Result.Errors.Select(c => c.Description).ToList()) };

            return new AuthModel
            {
                Message = "User Register Successfully",
                IsAuthenticated = true,
                Roles = new List<string> { RoleConsts.UserRole }
            };
        }
    }
}
