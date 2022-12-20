using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Domain.Entities
{
    public class Patient:BaseEntity
    {
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public decimal WeightKG { get; set; }

        public decimal HeightCM { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public string EmergencyContact { get; set; }

        public ICollection<MedicalRecord>? MedicalRecords { get; set; }

    }

    public class PatientValidator : AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(patient => patient.Contact)
                .NotEqual(patient => patient.EmergencyContact);
        }
    }
}
