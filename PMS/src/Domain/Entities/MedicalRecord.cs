using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicalRecord : BaseAuditableEntity
    {
        public DateTime SampleCollectedDate { get; set; }

        public decimal SugarMmol { get; set; }

        public decimal TemperatureCelcius { get; set; }

        public int PlateletMmol { get; set; }

        public decimal HemoglobinGdl { get; set; }

        public int PatientId { get; set; }

        public Patient? Patient { get; set; }
    }
}
