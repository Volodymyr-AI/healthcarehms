﻿using StaffMS.Core;
using StaffMS.Core.HospitalRelatedEntities;

namespace StaffMS.Application.Utils.Interfaces.Repositories;

public interface IDepartmentRepository

{
    Task<DepartmentEntity> GetByIdAsync(Guid id);
    Task<List<DepartmentEntity>> GetAllAsync();
    Task AddAsync(DepartmentEntity entity);
    Task SaveChangesAsync(DepartmentEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(DepartmentEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task AddPhoneNumberAsync(Guid id, DepartmentPhoneNumberEntity phoneNumberEntity);
    Task AddFacilityAsync(Guid hospitalId, DepartmentFacilityEntity facility);
    Task AddServiceAsync(Guid hospitalId, DepartmentServiceEntity service);
}