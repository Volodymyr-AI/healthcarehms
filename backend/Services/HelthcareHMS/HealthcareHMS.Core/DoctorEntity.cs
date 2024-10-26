namespace HealthcareHMS.Core;

public class DoctorEntity
{
    public Guid DoctorId { get; set; }
    public string DoctorName { get; set; }
    public string Specialization { get; set; }
    public string Bio { get; set; }
    public int YearsOfExperience { get; set; }
    public List<string> Licenses { get; set; }
    public List<string> Certifications { get; set; }

    public string MedicalSchool { get; set; }
    public List<string> ConditionsTreated { get; set; }

    public List<string> Practices { get; set; }
    public List<string> Services_Provided { get; set; }
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