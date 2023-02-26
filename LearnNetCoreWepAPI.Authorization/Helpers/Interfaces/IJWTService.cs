using LearnNetCoreWepAPI.DAL.models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.Authorization.Helpers.Interfaces
{
    public interface IJWTService
    {
        Task<string> Create(ApplicationUser user);

    }
}
