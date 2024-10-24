using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.MediatR.General.Hospitals.Commands.UpdateHospital
{
    public class UpdateHospitalCommand : IRequest<String>
    {
        public Guid HospitalAdminId { get; set; }
        public Guid GlobalAdminId {  get; set; }
        public Guid HospitalId { get; set; }

        public string HospitalName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string FacilitiesAvailable { get; set; }
        public string ServicesProvided { get; set; }
    }
}
