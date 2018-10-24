using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsabilityProject.Model
{
    public class SamplesSelectionModel
    {
        public String UserName { get; set; }
        public int? DepartmentId { get; set; }
        public int? UserRole { get; set; }
        public int? StartPulse { get; set; }
        public int? EndPulse { get; set; }
        public float? StartTemperature { get; set; }
        public float? EndTemperature { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
