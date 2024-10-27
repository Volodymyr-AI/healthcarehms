using HealthcareHMS.Core;
using HealthcareHMS.Core.HospitalRelatedEntities;

namespace HealthcareHMS.Application.Utils.Interfaces.Repositories;

public interface IHospitalRepository
{
    Task<HospitalEntity> GetByIdAsync(Guid id);
    Task<List<HospitalEntity>> GetAllAsync();
    Task AddAsync(HospitalEntity entity);
    Task SaveChangesAsync(HospitalEntity entity);
    Task UpdateAsync(HospitalEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task AddPhoneNumberAsync(Guid id, HospitalPhoneNumberEntity phoneNumberEntity);
    Task AddFacilityAsync(Guid hospitalId, HospitalFacilityEntity facility);
    Task AddServiceAsync(Guid hospitalId, HospitalServiceEntity service);
}