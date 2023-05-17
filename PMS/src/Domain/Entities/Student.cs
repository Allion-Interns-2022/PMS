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
    public class Student:BaseEntity
    {
        public string FullName { get; set; }

        //public DateTime DOB { get; set; }

        public string NIC { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public string Distance { get; set; }

        public string Remarks { get; set; }

        public DateTime SubmitDate { get; set; }

        //public ICollection<MedicalRecord>? MedicalRecords { get; set; }

    }
}
