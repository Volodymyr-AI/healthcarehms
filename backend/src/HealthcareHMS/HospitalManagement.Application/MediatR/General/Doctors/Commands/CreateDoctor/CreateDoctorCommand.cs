using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.MediatR.General.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<Guid>
    {
        public Guid HospitalId { get; set; }
        public string DoctorName { get; set; }
        
    }
}
