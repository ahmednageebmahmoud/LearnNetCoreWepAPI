
using LearnNetCoreWepAPI.DAL.Configrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LearnNetCoreWepAPI.models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        string ConnectionString = @"Data Source=DESKTOP-PCI8IKG;Initial Catalog=LearnNetCoreWepAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //Read Connection String From Appsetting.json
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new EmployeeConfigration().Configure(modelBuilder.Entity<Employee>());


            //Create Sequence With One Or More Table
          //  modelBuilder.HasSequence<int>("RegisterNo").StartsAt(5).IncrementsBy(9);
          //  modelBuilder.Entity<Employee>().Property(c => c.UserRegisterNO).HasDefaultValueSql("NEXT VALUE FOR RegisterNo");
          //  modelBuilder.Entity<Student>().Property(c => c.UserRegisterNO).HasDefaultValueSql("NEXT VALUE FOR RegisterNo");
          
            //Add Default Schema modelBuilder.HasDefaultSchema("HR");
            //Ignor Entity From Migration modelBuilder.Ignore<Media>();
            //Ignor Property From Migration modelBuilder.Entity<Media>().Ignore(c=> c.FileURL);
            //To Stop Listen Changes On Entity(Stop Migration To This Table Not Remove From DB) modelBuilder.Entity<Post>().ToTable("Posts", p => p.ExcludeFromMigrations());

            //Meny To Meny 
            /*
            modelBuilder.Entity<Post>()
                .HasMany(c => c.Medias)
                .WithMany(c => c.Posts)
                .UsingEntity<PostMedia>(

                p=> p.HasOne(c=> c.Media)
                .WithMany(c=> c.PostMedias)
                .HasForeignKey(c=> c.MediaId),

                p => p.HasOne(c => c.Post)
                .WithMany(c => c.PostMedias)
                .HasForeignKey(c => c.PostId)
                );*/



        }
        public DbSet<Employee> Employees { get; set; }

    }
}
