using HospitalManagement.Application.Utils.Interfaces;
using HospitalManagement.Core;
using MediatR;

namespace HospitalManagement.Application.MediatR.GlobalAdmin.Hospitals.Commands.CreateHospital
{
    public class CreateHospitalCommandHandler : IRequestHandler<CreateHospitalCommand, Guid>
    {
        private readonly IHospitalDbContext _dbContext;

        public CreateHospitalCommandHandler(IHospitalDbContext dbContext)
                => _dbContext = dbContext;
        public async Task<Guid> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
        {
            var hospital = new HospitalEntity
            {
                HospitalName = request.HospitalName,
                Address = request.Address,
                Email = request.Email,
            };

            await _dbContext.Hospitals.AddAsync(hospital, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            //For the future return instead of Guid
            string success = $"{hospital.HospitalName} with id {hospital.Id} created successfully";

            return hospital.Id;
        }
    }
}
