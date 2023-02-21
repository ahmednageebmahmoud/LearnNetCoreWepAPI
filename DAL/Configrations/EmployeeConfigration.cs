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

            builder.Property(c => c.Age)
                .IsRequired(true);

            //Rename Column Name builder.Property(c => c.Age) .HasColumnName("AgeFix");
            //Rename Table In DB builder.ToTable("OurEmployees");
            //Change Table Schema   builder.ToTable("Employeed", schema: "emps");
        }
    }
}
