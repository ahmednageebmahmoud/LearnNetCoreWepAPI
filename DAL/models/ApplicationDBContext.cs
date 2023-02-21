
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LearnNetCoreWepAPI.models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        //string ConnectionString= @"Data Source=DESKTOP-PCI8IKG;Initial Catalog=LearnNetCoreWepAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    //Read Connection String From Appsetting.json
        //    optionsBuilder.UseSqlServer(ConnectionString);
        //}

        public DbSet<Employee> Employees { get; set; }

    }
}
