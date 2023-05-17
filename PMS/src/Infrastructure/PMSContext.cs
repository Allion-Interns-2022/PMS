using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Infrastructure
{
    public class PMSContext:DbContext
    {
        public PMSContext(DbContextOptions<PMSContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<HostelStudent> Students { get; set; }
        public DbSet<Sibling> Siblings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            //modelBuilder.Entity<Patient>()
            //        .Property(p => p.HeightCM)
            //        .HasColumnType("DECIMAL(5,2)")
            //        .IsRequired();

            //modelBuilder.Entity<Patient>()
            //        .Property(p => p.WeightKG)
            //        .HasColumnType("DECIMAL(5,2)")
            //        .IsRequired();

            //HostelStudent hostelstudent = new HostelStudent();
            //HostelStudentValidator validator = new HostelStudentValidator();

            //ValidationResult results = validator.Validate(hostelstudent);

            //if (!results.IsValid)
            //{
            //    foreach (var failure in results.Errors)
            //    {
            //        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            //    }
            //}

            //modelBuilder.Entity<MedicalRecord>()
            //        .Property(m => m.SugarMmol)
            //        .HasColumnType("decimal(4,1)");

            //modelBuilder.Entity<MedicalRecord>()
            //        .Property(m => m.TemperatureCelcius)
            //        .HasColumnType("decimal(3,1)");

            //modelBuilder.Entity<MedicalRecord>()
            //        .Property(m => m.HemoglobinGdl)
            //        .HasColumnType("decimal(3,1)");

            modelBuilder.Entity<Sibling>()
                    .HasOne<HostelStudent>(m => m.Student)
                    .WithMany(p => p.Siblings)
                    .HasForeignKey(m => m.StudentId);


            base.OnModelCreating(modelBuilder);

        }

    }
}
