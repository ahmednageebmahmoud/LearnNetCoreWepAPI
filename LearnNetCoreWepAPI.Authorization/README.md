
# # ASP.NET Core Integration With JWT

This class library create to manage authorizations.

# # JWT
Install Pagekages In This Project
```
Install-Package System.IdentityModel.Tokens.Jwt
```

Install Pagekages In DAL Project
```
Install-Package Microsoft.AspNet.Identity.EntityFramework
```

Install Pagekages In In Main Project
```
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
```


Generate JWS key and Sign Payload 
```
https://8gwifi.org/jwsgen.jspJwt
```

Add JWT Information In appsetting.json
```
  "JWT": {
    "Key": "gPCtMjDvBqquVfX/M9OpihphtXo+Vm2pVuaPvABUGxA=",
    "Issure": "LearnJWTWithDotNetCore",
    "Audince": "SezerUsers",
    "DurationDays": 30
  }
```

Create Class Form Map JWT Information From appsetting.json
```
    public class JWT
    {
        public string Key { get; set; }
        public string Issure { get; set; }
        public string Audince { get; set; }
        public int DurationDays { get; set; }
    }
```

 
Create Map Values From Between JWT Session With JWT CLass
```
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
```
  
 
Create User Class Model And Inherent From IdentityUser To Add Custom Fields Like User Name And Last Name   
```
  public class ApplicationUser:IdentityUser
    {
        [Required,MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
    }
```

In DBContext We Must Be Inherent From IdentityDbContext Not DbContext Because We Need Add All Identity Tables
```
public class ApplicationDBContext : IdentityDbContext{}
```


Pass The Application User Class To Apply Your Custom Fields
```
public class ApplicationDBContext : IdentityDbContext<ApplicationUser>{}
```

Add Identity In Configration
```
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();
```

Now Create Migration And Update Data Base, Then Cresate A Empty Migraten To Insert Seed Data Like Seed Role Or Another
```
public class RoleConsts
{
    public static readonly string UserRole= "User";
    public static readonly string AdminRole = "Admin";
}

//Add Empty Migration
add-migration SeedRoles


//Insert User Role
  migrationBuilder.InsertData(
        table: "AspNetRoles",
        columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
        values: new[] {Guid.NewGuid().ToString(),"User", RoleConsts.UserRole,Guid.NewGuid().ToString() }
    );

//Insert Admin Role
    migrationBuilder.InsertData(
        table: "AspNetRoles",
        columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
        values: new[] { Guid.NewGuid().ToString(), "Admin", RoleConsts.AdminRole, Guid.NewGuid().ToString() }
    );
```

Create Auth Service

Pass Auth Service As Scoped
```
builder.Services.AddScoped<IAuthService, AuthService>();
```

Tell App Use Authentication With Each Request, Add This Fellowing Line Before app.UseAuthorization();
```
app.UseAuthentication();
```

Add Default Authenticate Scheme One Time In Project And Add Decode Token Setting 
```
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = true;
    o.SaveToken = false;
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience  =     true,
        ValidateLifetime=true,
        ValidIssuer = builder.Configuration["JWT:Issure"],
        ValidAudience= builder.Configuration["JWT:Audince"],
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});
```

Generate JWT Token
```
       var Roles = await _userManger.GetRolesAsync(user);
            var UserClimes = await _userManger.GetClaimsAsync(user);

            foreach (var role in Roles)
            {
                UserClimes.Add(new Claim("roles", role));
            }

            var Clamis = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim("uid",user.Id)
            }.Union(UserClimes);

            var SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwt.Key));
            var SigningCredentials = new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(
                issuer: this._jwt.Issure,
                audience: this._jwt.Audince,
                claims: Clamis,
                expires: DateTime.Now.AddDays(this._jwt.DurationDays),
                signingCredentials: SigningCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(Token);
```

