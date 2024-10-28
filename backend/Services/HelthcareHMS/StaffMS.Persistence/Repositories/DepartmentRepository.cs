using StaffMS.Application.Utils.Exceptions;
using StaffMS.Application.Utils.Interfaces.Repositories;
using StaffMS.Core;
using StaffMS.Core.HospitalRelatedEntities;
using Microsoft.EntityFrameworkCore;

namespace StaffMS.Persistence.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    StaffMSDbContext _dbContext;

    public DepartmentRepository(StaffMSDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<DepartmentEntity> GetByIdAsync(Guid id)
    {
        var hospital = await _dbContext.Departments.FindAsync(id);
        if (hospital == null)
        {
            throw new NotFoundException(nameof(DepartmentEntity), id);
        }
        return hospital;
    }

    public async Task<List<DepartmentEntity>> GetAllAsync()
    {
        return await _dbContext.Departments.ToListAsync(); 
    }

    public async Task AddAsync(DepartmentEntity entity)
    {
        await _dbContext.Departments.AddAsync(entity);
    }

    public async Task SaveChangesAsync(DepartmentEntity entity)
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(DepartmentEntity entity, CancellationToken cancellationToken)
    {
        _dbContext.Departments.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var hospital = await _dbContext.Departments.FindAsync(id);
        if (hospital != null)
        {
            _dbContext.Departments.Remove(hospital);
            await _dbContext.SaveChangesAsync(cancellationToken); 
        }
        else
        {
            throw new NotFoundException(nameof(DepartmentEntity), id);
        }
    }
    
    public async Task AddPhoneNumberAsync(Guid hospitalId, DepartmentPhoneNumberEntity phoneNumber)
    {
        var hospital = await GetByIdAsync(hospitalId);
        hospital.PhoneNumbers.Add(phoneNumber);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task AddFacilityAsync(Guid hospitalId, DepartmentFacilityEntity facility)
    {
        var hospital = await GetByIdAsync(hospitalId);
        hospital.DepartmentFacilities.Add(facility);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddServiceAsync(Guid hospitalId, DepartmentServiceEntity service)
    {
        var hospital = await GetByIdAsync(hospitalId);
        hospital.DepartmentServices.Add(service);
        await _dbContext.SaveChangesAsync();
    }
}