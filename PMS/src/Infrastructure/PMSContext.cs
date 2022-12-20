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
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Patient>()
                    .Property(p => p.HeightCM)
                    .HasColumnType("DECIMAL(5,2)")
                    .IsRequired();

            modelBuilder.Entity<Patient>()
                    .Property(p => p.WeightKG)
                    .HasColumnType("DECIMAL(5,2)")
                    .IsRequired();

            Patient patient = new Patient();
            PatientValidator validator = new PatientValidator();

            ValidationResult results = validator.Validate(patient);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            modelBuilder.Entity<MedicalRecord>()
                    .Property(m => m.SugarMmol)
                    .HasColumnType("decimal(4,1)");

            modelBuilder.Entity<MedicalRecord>()
                    .Property(m => m.TemperatureCelcius)
                    .HasColumnType("decimal(3,1)");

            modelBuilder.Entity<MedicalRecord>()
                    .Property(m => m.HemoglobinGdl)
                    .HasColumnType("decimal(3,1)");

            modelBuilder.Entity<MedicalRecord>()
                    .HasOne<Patient>(m => m.Patient)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(m => m.PatientId);


            base.OnModelCreating(modelBuilder);

        }

    }
}
