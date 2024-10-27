namespace HealthcareHMS.Core;

public class DoctorEntity
{
    public Guid DoctorId { get; set; }
    public string DoctorName { get; set; }
    public string Specialization { get; set; }
    public string Bio { get; set; }
    public int YearsOfExperience { get; set; }
    public ICollection<LicenseEntity> Licenses { get; set; }
    public ICollection<CertificationEntity> Certifications { get; set; }

    public string MedicalSchool { get; set; }
    public ICollection<ConditionTreatedEntity> Conditions { get; set; }

    public ICollection<PractiseEntity> Practises { get; set; }
    public ICollection<ServiceProvidedEntity> ServiceProvided { get; set; }
    public bool Appointment_Availability { get; set; }

//Auth
    public string Email { get; set; }
    public string Login  { get; set; }
    public string Password { get; set; }    

// Doctor Shift hours
    public List<DoctorWorkinghoursEntity> WorkingHours { get; set; }

    public Guid HospitalId { get; set; }
    public HospitalEntity Hospital { get; set; }
}