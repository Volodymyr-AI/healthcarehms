namespace HealthcareHMS.Core;

public class HospitalAdminEntity
{
    public Guid HospitalAdminId { get; set; }
    public string AdminName { get; set; }
    public string Email {  get; set; }
    public string Login {  get; set; }
    public string Password { get; set; }

    // Connection with the hospital
    public Guid HospitalId { get; set; }
    public HospitalEntity Hospital { get; set; }
}