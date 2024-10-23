using HospitalManagement.Application.Utils.Exceptions;
using HospitalManagement.Application.Utils.Interfaces;
using HospitalManagement.Core;
using MediatR;

namespace HospitalManagement.Application.MediatR.GlobalAdmin.Hospitals.Commands.UpdateHospital
{
    internal class UpdateHospitalGACommandHandler : IRequestHandler<UpdateHospitalGACommand, Unit>
    {
        private IHospitalDbContext _dbContext;

        public UpdateHospitalGACommandHandler(IHospitalDbContext dbContext)
                => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateHospitalGACommand request, CancellationToken cancellationToken)
        {
            var hospital =
                await _dbContext.Hospitals.FindAsync(request.HospitalId);
            if (hospital == null)
            {
                throw new NotFoundException(nameof(HospitalEntity), request.HospitalId);
            }

            hospital.AddGoogleMyBusiness = request.AddGoogleMyBusiness;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
