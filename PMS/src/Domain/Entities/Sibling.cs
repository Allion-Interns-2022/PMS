using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sibling:BaseEntity
    {
        public string FullName { get; set; }

        public string EducationalInstitute { get; set; }

        public string AcademicYear  { get; set; }

        public int StudentId { get; set; } 

        public HostelStudent? Student { get; set; }
    }
}
