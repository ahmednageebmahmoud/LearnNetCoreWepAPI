
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
using var Tran = this._Entity._context.Database.BeginTransaction();
    
// Yet another piece of code...
   
// Commit to and Make Pouint
Tran.Commit();
   
//Roll Back 
Tran.Rollback();
```
Example of a Transaction with a Save Point
```
using var TranPointEX = this._Entity._context.Database.BeginTransaction();
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
