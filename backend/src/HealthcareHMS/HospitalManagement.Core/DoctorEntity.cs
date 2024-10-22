using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core
{
    public class DoctorEntity
    {
        public Guid Id { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
        public int YearsOfExperience { get; set; }
        public List<string> Licenses { get; set; }
        public List<string> Certifications { get; set; }

        public string MedicalSchool { get; set; }
        public List<string> ConditionsTreated { get; set; }

        public List<string> Practices { get; set; }
        public List<string> Services_Provided { get; set; }
        public List<WorkingHoursEntity> WorkingHours { get; set; }
        public bool Appointment_Availability { get; set; }

        public Guid HospitalAdmin { get; set; }
        public Guid HospitalId { get; set; }
        public HospitalEntity Hospital { get; set; }
    }
}
