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
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<DateTime> WorkingHours { get; set; }
        public bool AddGoogleMyBusiness { get; set; }
        public bool EmergencyServicesIsAvaliable { get; set; }
        public string FacilitiesAvailable { get; set; }
        public string ServicesProvided { get; set; }
        public List<DoctorEntity> Doctors { get; set; }
        public Guid GlobalAdminId { get; set; }
        public Guid HospitalAdminId { get; set; }
    }
}
