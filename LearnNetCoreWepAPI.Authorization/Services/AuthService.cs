using LearnNetCoreWepAPI.Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LearnNetCoreWepAPI.DAL.models;
using LearnNetCoreWepAPI.DAL.Helpers;
using LearnNetCoreWepAPI.Authorization.Helpers.Interfaces;
using LearnNetCoreWepAPI.Authorization.Services;
using System.IdentityModel.Tokens.Jwt;

namespace LearnNetCoreWepAPI.BLL.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManger;
        private readonly IJWTService _jwtService;
        public AuthService(UserManager<ApplicationUser> userManger, IJWTService authService)
        {
            _userManger = userManger;
            _jwtService = authService;
        }


        public async Task<AuthModel> Register(RegisterModel register)
        {
            //Check From Email
            if (await this._userManger.FindByEmailAsync(register.Email) is not null)
                return new AuthModel { Message = "Email Is Alredy Used" };

            //Check From UserName
            if (await this._userManger.FindByNameAsync(register.UserName) is not null)
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

            //Create JWT Token
            var Token = await this._jwtService.Create(User);
            return new AuthModel
            {
                Message = "User Register Successfully",
                IsAuthenticated = true,
                Roles = new List<string> { RoleConsts.UserRole },
                Token = Token
            };
        }

        public async Task<AuthModel> Login(LoginModel login)
        {

            var User = await this._userManger.FindByNameAsync(login.UserName);

            //Check From UserName And Password
           if(User is   null || !(await _userManger.CheckPasswordAsync(User,login.Password)))
                return new AuthModel { Message = "User Name Or Password Is Incorrect" };

            //Create JWT Token
            var Token = await this._jwtService.Create(User);
            return new AuthModel
            {
                Message = "User Login Successfully",
                IsAuthenticated = true,
                Roles = new List<string> { RoleConsts.UserRole },
                Token = Token
            };
        }


    }
}
