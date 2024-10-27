using HealthcareHMS.Application.Utils.Interfaces.Infrastructure;
using HealthcareHMS.Application.Utils.Interfaces.Repositories;
using HealthcareHMS.Core;
using MediatR;

namespace HealthcareHMS.Application.MediatR.GlobalAdmin.Hospital.Commands.Create;

public class CreateHospitalCommandHandler : IRequestHandler<CreateHospitalCommand, HospitalEntity>
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly IHealthcareHMSDbContext _dbContext;

    public CreateHospitalCommandHandler(IHospitalRepository hospitalRepository, IHealthcareHMSDbContext dbContext)
    {
        _hospitalRepository = hospitalRepository;
        _dbContext = dbContext;
    }

    public async Task<HospitalEntity> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
    {
        var newHospital = new HospitalEntity
        {
            Id = Guid.NewGuid(),
            HospitalName = request.HospitalName,
            Email = request.Email,
            //GlobalAdminId = request.GlobalAdminId,
        };
        
        await _hospitalRepository.AddAsync(newHospital);
        await _hospitalRepository.SaveChangesAsync(newHospital);
        
        return newHospital;
    }
}