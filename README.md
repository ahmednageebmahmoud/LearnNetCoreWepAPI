
# # ASP.Net Core With EF Core Examples

This Project For Simple Examples
# # EF Migrations
Create Migration 
```
add-migration firstMigration
```
Remove Last Migration 
```
remove-migration
```
App All Migrations Not Applid In DB 
```
update-migration
```
# # EF Database Actions

Transaction Example
```
using var Tran = this._Entity._context.Database.BeginTransaction();
    
//Another Code ...
   
//Commit And Create Pouint
Tran.Commit();
   
//Roll Back 
Tran.Rollback();
```
Transaction Example With Save Pint
```
using var TranPointEX= this._Entity._context.Database.BeginTransaction();
//Another Code ...
   
//Commit And Create Pouint
TranPointEX.CreateSavepoint("FirstPoint");
   
//Another Code ...
   
//Roll Back To Specific Point
TranPointEX.RollbackToSavepoint("FirstPoint");

# # EF Flunt API
```
Entity Builder: Create Index
```
builder.HasIndex(c=> new{ c.Age,c.Name })
```
Entity Builder: Create Index Unique
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
Entity Builder: Rename Column Name 
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
Entity Builder: One To One Relation
```
builder
    .HasOne(c => c.Media)
    .WithOne(c => c.Employee)
    .HasForeignKey<Media>(c => c.EmpoId);
```
Entity Builder: Many To Many Relation
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

Model Builder: Create Sequence With One Or More Table
```
//Create Sequence (Model Builder)
modelBuilder.HasSequence<int>("RegisterNo")
    .StartsAt(5) //Optional
    .IncrementsBy(9); //Optional

//Bind Sequence With Employee Entity
modelBuilder.Entity<Employee>()
    .Property(c => c.UserRegisterNO)
    .HasDefaultValueSql("NEXT VALUE FOR RegisterNo");

//Bind Sequence With Student Entity
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
Model Builder: To Stop Listening To Changes On Entity (Stop Migration To This Table, Do Not Remove From Database)
```
modelBuilder.Entity<Post>().ToTable("Posts", p => p.ExcludeFromMigrations());
```
            
