
using LearnNetCoreWepAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.DAL.Configrations
{
    /// <summary>
    /// Employee Configration To Apply Flunt API And Another
    /// </summary>
    internal class EmployeeConfigration:IEntityTypeConfiguration<Employee>
    {
         public void Configure(EntityTypeBuilder<Employee> builder)
        {

            //builder.Property(c => c.Age) .IsRequired(true);

            //Create Index Unique
            //builder.HasIndex(c=> new{ c.Age,c.Name }).IsUnique();


            //One To One Relation
           // builder
           //     .HasOne(c => c.Media)
           //     .WithOne(c => c.Employee)
           //     .HasForeignKey<Media>(c => c.EmpoId);

            //Change Column Max Length builder.Property(c => c.Name).HasMaxLength(200);
            //Change Column Type builder.Property(c => c.Age) .HasColumnType("float");
            //Rename Column Name builder.Property(c => c.Age) .HasColumnName("AgeFix");
            //Rename Table In DB builder.ToTable("OurEmployees");
            //Change Table Schema   builder.ToTable("Employeed", schema: "emps");
        }
    }
}
