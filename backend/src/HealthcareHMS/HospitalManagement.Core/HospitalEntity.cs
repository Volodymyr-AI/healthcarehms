using HealthcareHMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core
{
    public class HospitalEntity
    {
        public Guid Id { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public List<WorkingHoursEntity> WorkingHours { get; set; }
        public bool AddGoogleMyBusiness { get; set; }
        public bool EmergencyServicesIsAvaliable { get; set; }
        public string FacilitiesAvailable { get; set; }
        public string ServicesProvided { get; set; }
        public List<DoctorEntity> Doctors { get; set; }

        // 1 global admin
        public Guid GlobalAdminId { get; set; }

        // 1 admin of hospital
        public HospitalAdminEntity HospitalAdmin { get; set; }
    }
}
