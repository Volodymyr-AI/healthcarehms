using HealthcareHMS.Application.Utils.Exceptions;
using HealthcareHMS.Application.Utils.Interfaces.Repositories;
using HealthcareHMS.Core;
using HealthcareHMS.Core.HospitalRelatedEntities;
using Microsoft.EntityFrameworkCore;

namespace HealthcareHMS.Persistence.Repositories;

public class HospitalRepository : IHospitalRepository
{
    HealthcareHMSDbContext _dbContext;

    public HospitalRepository(HealthcareHMSDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<HospitalEntity> GetByIdAsync(Guid id)
    {
        var hospital = await _dbContext.Hospitals.FindAsync(id);
        if (hospital == null)
        {
            throw new NotFoundException(nameof(HospitalEntity), id);
        }
        return hospital;
    }

    public async Task<List<HospitalEntity>> GetAllAsync()
    {
        return await _dbContext.Hospitals.ToListAsync(); 
    }

    public async Task AddAsync(HospitalEntity entity)
    {
        await _dbContext.Hospitals.AddAsync(entity);
    }

    public async Task SaveChangesAsync(HospitalEntity entity)
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(HospitalEntity entity, CancellationToken cancellationToken)
    {
        _dbContext.Hospitals.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var hospital = await _dbContext.Hospitals.FindAsync(id);
        if (hospital != null)
        {
            _dbContext.Hospitals.Remove(hospital);
            await _dbContext.SaveChangesAsync(cancellationToken); 
        }
        else
        {
            throw new NotFoundException(nameof(HospitalEntity), id);
        }
    }
    
    public async Task AddPhoneNumberAsync(Guid hospitalId, HospitalPhoneNumberEntity phoneNumber)
    {
        var hospital = await GetByIdAsync(hospitalId);
        hospital.PhoneNumbers.Add(phoneNumber);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task AddFacilityAsync(Guid hospitalId, HospitalFacilityEntity facility)
    {
        var hospital = await GetByIdAsync(hospitalId);
        hospital.HospitalFacilities.Add(facility);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddServiceAsync(Guid hospitalId, HospitalServiceEntity service)
    {
        var hospital = await GetByIdAsync(hospitalId);
        hospital.HospitalServices.Add(service);
        await _dbContext.SaveChangesAsync();
    }
}