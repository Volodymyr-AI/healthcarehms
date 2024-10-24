using HospitalManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareHMS.Core
{
    public class HospitalAdminEntity
    {
        public Guid HospitalAdminId { get; set; }
        public string Email {  get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }

        public Guid HospitalId { get; set; }
        public HospitalEntity Hospital { get; set; }

    }
}
