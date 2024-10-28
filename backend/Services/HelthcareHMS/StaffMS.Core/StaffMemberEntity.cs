namespace StaffMS.Core;

public class StaffMemberEntity
{
    public Guid StaffId { get; set; }
    public string StaffName { get; set; }
    public string Specialization { get; set; }
    public string Bio { get; set; }
    public int YearsOfExperience { get; set; }
    public ICollection<LicenseEntity> Licenses { get; set; }
    public ICollection<CertificationEntity> Certifications { get; set; }

    public string School { get; set; }
    public ICollection<Specialisations> Specialisations { get; set; }

    public ICollection<PractiseEntity> Practises { get; set; }
    public ICollection<ServiceProvidedEntity> ServicesProvided { get; set; }
    public bool Appointment_Availability { get; set; }

//Auth
    public string Email { get; set; }
    public string Login  { get; set; }
    public string Password { get; set; }    

// StaffMember Shift hours
    public List<StaffWorkinghoursEntity> WorkingHours { get; set; }

    public Guid DepartmentId { get; set; }
    public DepartmentEntity Department { get; set; }
}