using StaffMS.WebAPI.Domain.Additional;

namespace StaffMS.WebAPI.Domain.UserRelated;

public class StaffMemberEntity
{
    public Guid Id { get; set; }
    public string StaffName { get; set; }
    public string Specialization { get; set; }
    public string Bio { get; set; }
    public int YearsOfExperience { get; set; }
    public ICollection<LicenseEntity> Licenses { get; set; }
    public ICollection<CertificationEntity> Certifications { get; set; }

    public string School { get; set; }
    public ICollection<SpecialisationEntity> Specialisations { get; set; }

    public ICollection<PractiseEntity> Practises { get; set; }
    public ICollection<ServiceProvidedEntity> ServicesProvided { get; set; }
    //public bool Appointment_Availability { get; set; }

    // StaffMember Shift hours
    public List<ShiftHoursEntity> WorkingHours { get; set; }

    public Guid DepartmentId { get; set; }
    public DepartmentEntity Department { get; set; }
}