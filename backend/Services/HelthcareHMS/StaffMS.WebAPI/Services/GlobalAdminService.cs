using Microsoft.EntityFrameworkCore;
using StaffMS.WebAPI.Domain.UserRelated;
using StaffMS.WebAPI.Infrastructure;
using UserManagement.Service.Infrastructure;

namespace StaffMS.WebAPI.Services;

public class GlobalAdminService
{
    private readonly StaffMSDbContext _context;
    private readonly UserManagementDbContext _userContext;

    public GlobalAdminService(StaffMSDbContext context, UserManagementDbContext userContext)
    {
        _context = context;
        _userContext = userContext;
    }
    
    public async Task<GlobalAdminEntity> UpdateGlobalAdminAsync(Guid id, GlobalAdminEntity updatedAdmin)
    {
        var admin = await _context.GlobalAdmins.FindAsync(id);
        if (admin == null) throw new KeyNotFoundException("GlobalAdmin not found");
        
        admin.Name = updatedAdmin.Name;
        admin.Phone = updatedAdmin.Phone;

        await _context.SaveChangesAsync();
        return admin;
    }
    
    public async Task<DepartmentEntity> CreateDepartmentAsync(DepartmentEntity newDepartment)
    {
        _context.Departments.Add(newDepartment);
        await _context.SaveChangesAsync();
        return newDepartment;
    }
    
    public async Task<DepartmentEntity> UpdateDepartmentAsync(Guid departmentId, DepartmentEntity updatedDepartment)
    {
        var department = await _context.Departments
            .Include(d => d.DepartmentFacilities)
            .Include(d => d.DepartmentServices)
            .FirstOrDefaultAsync(d => d.Id == departmentId);
    
        if (department == null)
            throw new KeyNotFoundException("Department not found");

        department.DepartmentName = updatedDepartment.DepartmentName;
        department.Address = updatedDepartment.Address;
        department.Email = updatedDepartment.Email;
        department.OpenTime = updatedDepartment.OpenTime;
        department.CloseTime = updatedDepartment.CloseTime;
        department.AddGoogleMyBusiness = updatedDepartment.AddGoogleMyBusiness;
        department.ServicesAvailable = updatedDepartment.ServicesAvailable;
        
        department.DepartmentFacilities
            .RemoveAll(df => !updatedDepartment.DepartmentFacilities.Any(udf => udf.Id == df.Id));

        foreach (var facility in updatedDepartment.DepartmentFacilities)
        {
            var existingFacility = department.DepartmentFacilities
                .FirstOrDefault(df => df.Id == facility.Id);
        
            if (existingFacility == null)
                department.DepartmentFacilities.Add(facility);
            else
                existingFacility.Facility = facility.Facility;
        }

        department.DepartmentServices
            .RemoveAll(ds => !updatedDepartment.DepartmentServices.Any(uds => uds.Id == ds.Id));

        foreach (var service in updatedDepartment.DepartmentServices)
        {
            var existingService = department.DepartmentServices
                .FirstOrDefault(ds => ds.Id == service.Id);
        
            if (existingService == null)
                department.DepartmentServices.Add(service);
            else
                existingService.Service = service.Service;
        }

        await _context.SaveChangesAsync();
        return department;
    }
    
    public async Task DeleteDepartmentAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var department = await _context.Departments.FindAsync(departmentId, cancellationToken);
        if (department == null) throw new KeyNotFoundException("Department not found");

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<StaffAdminEntity> UpdateStaffAdminAsync(Guid staffAdminId, StaffAdminEntity updatedStaffAdmin, CancellationToken cancellationToken)
    {
        var staffAdmin = await _context.StaffAdmins.FindAsync(staffAdminId, cancellationToken);
        if (staffAdmin == null) throw new KeyNotFoundException("StaffAdmin not found");

        staffAdmin.AdminName = updatedStaffAdmin.AdminName;
        await _context.SaveChangesAsync(cancellationToken);
        return staffAdmin;
    }
    
    public async Task DeleteStaffAdminAsync(Guid staffAdminId, CancellationToken cancellationToken)
    {
        var staffAdmin = await _context.StaffAdmins.FindAsync(staffAdminId, cancellationToken);
        var stafAdmin = await _userContext.Users.FindAsync(staffAdminId, cancellationToken);
        if (staffAdmin == null || stafAdmin == null) throw new KeyNotFoundException("StaffAdmin not found");

        _context.StaffAdmins.Remove(staffAdmin);
        await _context.SaveChangesAsync(cancellationToken);

        _userContext.Users.Remove(stafAdmin);
        await _userContext.SaveChangesAsync(cancellationToken); 
    }
    
    public async Task<StaffMemberEntity> UpdateStaffMemberAsync(Guid staffMemberId, StaffMemberEntity updatedStaffMember, CancellationToken cancellationToken)
    {
        var staffMember = await _context.StaffMembers
            .Include(sm => sm.Licenses)
            .Include(sm => sm.Certifications)
            .Include(sm => sm.Specialisations)
            .Include(sm => sm.Practises)
            .Include(sm => sm.ServicesProvided)
            .FirstOrDefaultAsync(sm => sm.Id == staffMemberId, cancellationToken);
    
        if (staffMember == null) throw new KeyNotFoundException("StaffMember not found");

        staffMember.StaffName = updatedStaffMember.StaffName;
        staffMember.Specialization = updatedStaffMember.Specialization;
        staffMember.Bio = updatedStaffMember.Bio;
        staffMember.YearsOfExperience = updatedStaffMember.YearsOfExperience;
        staffMember.School = updatedStaffMember.School;

        // Update collections
        

        await _context.StaffMembers.AddAsync(staffMember,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return staffMember;
    }
    
    public async Task DeleteStaffMemberAsync(Guid staffMemberId, CancellationToken cancellationToken)
    {
        var staffMember = await _context.StaffMembers.FindAsync(staffMemberId, cancellationToken);
        var stafMember = await _userContext.Users.FindAsync(staffMemberId, cancellationToken);
        if (staffMember == null || stafMember == null) throw new KeyNotFoundException("StaffMember not found");
        
        _context.StaffMembers.Remove(staffMember);
        await _context.SaveChangesAsync(cancellationToken);
        
        //await _userManagementService.DeleteUserAsync(staffMemberId);
        _userContext.Users.Remove(stafMember);
        await _userContext.SaveChangesAsync(cancellationToken);
    }
}