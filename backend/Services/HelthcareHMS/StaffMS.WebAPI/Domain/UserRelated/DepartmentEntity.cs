using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Domain.UserRelated;

public class DepartmentEntity
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; }
    public string Address { get; set; }
    public List<DepartmentPhoneNumberEntity> PhoneNumbers { get; set; }
    public string Email { get; set; }
    public TimeSpan OpenTime { get; set; }
    public TimeSpan CloseTime { get; set; }
    public bool AddGoogleMyBusiness { get; set; }
    public bool ServicesAvailable { get; set; }

    public List<DepartmentFacilityEntity> DepartmentFacilities { get; set; }
    
    public List<DepartmentServiceEntity> DepartmentServices { get; set; }

    //Staffs working in the hospital
    public List<StaffMemberEntity> Staffmembers { get; set; }

    // Global admin
    public Guid GlobalAdminId { get; set; }

    // Staffadmin of department
    public StaffAdminEntity StaffAdmin { get; set; }
}