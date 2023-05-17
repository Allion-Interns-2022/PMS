using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HostelStudent:Student
    {
        public string MaritalStatus { get; set; }

        public string FatherOccupation { get; set; }

        public string MotherOccupation { get; set; }

        public float FatherIncome { get; set; }

        public float MotherIncome { get;set; }

        public ICollection<Sibling>? Siblings { get; set; }
    }
}
