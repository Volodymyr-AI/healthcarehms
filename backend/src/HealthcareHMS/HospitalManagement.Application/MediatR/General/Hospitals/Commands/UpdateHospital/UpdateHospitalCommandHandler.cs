using HospitalManagement.Application.Utils.Exceptions;
using HospitalManagement.Application.Utils.Interfaces;
using HospitalManagement.Core;
using MediatR;

namespace HospitalManagement.Application.MediatR.General.Hospitals.Commands.UpdateHospital
{
    public class UpdateHospitalCommandHandler : IRequestHandler<UpdateHospitalCommand, String>
    {
        private IHospitalDbContext _dbContext;

        public UpdateHospitalCommandHandler(IHospitalDbContext dbContext) => _dbContext = dbContext;

        public async Task<String> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
        {
            var hospital =
                await _dbContext.Hospitals.FindAsync(request.HospitalId);

            if (hospital == null)
            {
                throw new NotFoundException(nameof(HospitalEntity), request.HospitalId);
            }

            if (hospital.HospitalAdminId != request.HospitalAdminId && hospital.GlobalAdminId != request.GlobalAdminId)
            {
                throw new UnauthorizedAccessException("No permission to modify");
            }

            hospital.HospitalName = request.HospitalName;
            hospital.Email = request.Email;
            hospital.Address = request.Address;
            hospital.PhoneNumbers = request.PhoneNumbers;
            hospital.FacilitiesAvailable = request.FacilitiesAvailable;
            hospital.ServicesProvided = request.ServicesProvided;
            
            await _dbContext.SaveChangesAsync(cancellationToken);

            return $"{hospital.HospitalName} information updated successfully.";
        }
    }
}
