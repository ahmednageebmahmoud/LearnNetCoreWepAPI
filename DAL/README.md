
# # ASP.NET Core With EF Core Examples

This project includes simple examples.
# # EF Migrations
Create Migration 
```
add-migration firstMigration
```
Remove the previous migration.
```
remove-migration
```
Apply All Migrations Are Inapplicable in the Database
```
update-migration
```
# # EF Database Actions

Transaction Example
```
using var Tran = db._context.Database.BeginTransaction();
    
// Yet another piece of code...
   
// Commit to and Make Pouint
Tran.Commit();
   
//Roll Back 
Tran.Rollback();
```
Example of a Transaction with a Save Point
```
using var TranPointEX = db._context.Database.BeginTransaction();
// Yet another piece of code...
   
// Make and Commit to Poutine
TranPointEX.CreateSavepoint("FirstPoint");
   
// Yet another piece of code...
   
// Rollback To a Specific Point
TranPointEX.RollbackToSavepoint("FirstPoint");

# # EF Flunt API
```
Entity Builder: Create an Index
```
builder.HasIndex(c=> new{ c.Age,c.Name })
```

Entity Builder: Create an Unique Index  
```
builder.HasIndex(c=> new{ c.Age,c.Name }).IsUnique();
```

Entity Builder: Change Column Max Length 
```
builder.Property(c => c.Name).HasMaxLength(200);
```

Entity Builder: Change Column Type 
```
builder.Property(c => c.Age) .HasColumnType("float");
```

Entity Builder: Rename column name
```
builder.Property(c => c.Age) .HasColumnName("AgeFix");
```

Entity Builder: Rename Table In DB 
```
builder.ToTable("OurEmployees");
```

Entity Builder: Change Table Schema
```
builder.ToTable("Employeed", schema: "emps");
```

Entity Builder: One-to-One Relationship
```
builder
    .HasOne(c => c.Media)
    .WithOne(c => c.Employee)
    .HasForeignKey<Media>(c => c.EmpoId);
```

Entity Builder: Many-to-Many Relationship
```
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
);
```

Model Builder: Create A Sequence With One Or More Table
```
//Create Sequence  Uning Model Builder
modelBuilder.HasSequence<int>("RegisterNo")
    .StartsAt(5) //Optional
    .IncrementsBy(9); //Optional

Employee Entity Bind Sequence
modelBuilder.Entity<Employee>()
    .Property(c => c.UserRegisterNO)
    .HasDefaultValueSql("NEXT VALUE FOR RegisterNo");

Student Entity Bind Sequence
modelBuilder.Entity<Student>()
    .Property(c => c.UserRegisterNO)
    .HasDefaultValueSql("NEXT VALUE FOR RegisterNo");
```

Model Builder: Add Default Schema
```
modelBuilder.HasDefaultSchema("HR");
```

Model Builder: Ignor Entity From Migration 
```
modelBuilder.Ignore<Media>();
```

Model Builder: Ignor Property From Migration
```
modelBuilder.Entity<Media>().Ignore(c=> c.FileURL);
```

Model Builder: Stop Listening To Changes On Entity (Stop Migration To This Table, Do Not Remove From Database)
```
modelBuilder.Entity<Post>().ToTable("Posts", p => p.ExcludeFromMigrations());
```

## EF Queries
Bulk Delete: extension method let you delete a large number of entities in your database without load them in app
 ```
//Example 1 Delete All Entites
db.Employee
    .ExecuteDelete();

//Example 2 Delete All Entites Wehre Age Greater Than 50
db.Employee
    .Where(c => c.Age > 50)
    .ExecuteDelete();

//Example 3 Skip First 90 Entity And Delete Another
db.Employee
    .Skip(90)
    .ExecuteDelete();
 ```

Bulk Update: extension method let you update a large number of entities in your database without load them in app
```
//Example 1 Update All Entites
db.Employee
    .ExecuteUpdate(e=> 
    e.SetProperty(p=> p.FullName,p=> p.FirstName+" "+p.LastName));

//Example 2 Update All Entites Wehre Age Greater Than 50
db.Employee
    .Where(c => c.Age > 50)
    .ExecuteUpdate(e => 
        e.SetProperty(p => p.FullName, p => p.FirstName + " " + p.LastName));

//Example 3 Skip First 90 Entity And Update Another
db.Employee
    .Skip(90)
    .ExecuteUpdate(e => 
        e.SetProperty(p => p.FullName, p => p.FirstName + " " + p.LastName));
```

Loading Related Data: Eager Loading
```
//Include: Load Auther Entity With Each Book
db.book
    .Include(c => c.Auther)
    .ToList();

//ThenInclude: Load Auther Entity And Load Auther Address Entity With Each Book
db.book
    .Include(c => c.Auther)
    .ThenInclude(c => c.Address)
    .ToList();

//Microsoft Documentation Example
var blogs = context.Blogs
        .Include(blog => blog.Posts)
        .ThenInclude(post => post.Author)
        .ThenInclude(author => author.Photo)
        .Include(blog => blog.Owner)
        .ThenInclude(owner => owner.Photo)
        .ToList();
```

Loading Related Data: Explicit Loading You can also explicitly load a navigation property by executing a separate query that returns the related entities. If change tracking is enabled, then when a query materializes an entity, EF Core will automatically set the navigation properties of the newly-loaded entity to refer to any entities already loaded, and set the navigation properties of the already-loaded entities to refer to the newly loaded entity.
```
var userNeedDisplyBlogPosts=false;
var blogXXXZZZYYY=db.Blogs.Find(6); 

if(userNeedDisplyBlogPosts)
{
    db.Entry(blogXXXZZZYYY)
        .Collection(u => u.Posts)
        .Query()
        .Where(c => c.PostIsActive == true)
        .Load();
}
```

Loading Related Data: Lazy Loading
```
//First Install The Package
Microsoft.EntityFrameworkCore.Proxies

//Second User Extiontion Method In OnConfiguring
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseLazyLoadingProxies() // Important
        .UseSqlServer(myConnectionString);

//Make certain that your collection is essential, such as 
public virtual ICollection<Post> Posts { get; set; }
```
    
  
 
        
