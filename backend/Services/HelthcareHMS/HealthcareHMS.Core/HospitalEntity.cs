using HealthcareHMS.Core.HospitalRelatedEntities;

namespace HealthcareHMS.Core;

public class HospitalEntity
{
    public Guid Id { get; set; }
    public string HospitalName { get; set; }
    public string Address { get; set; }
    public List<HospitalPhoneNumberEntity> PhoneNumbers { get; set; }
    public string Email { get; set; }
    public TimeSpan OpenTime { get; set; }
    public TimeSpan CloseTime { get; set; }
    public bool AddGoogleMyBusiness { get; set; }
    public bool EmergencyServicesIsAvaliable { get; set; }

    public List<HospitalFacilityEntity> HospitalFacilities { get; set; }
    
    public List<HospitalServiceEntity> HospitalServices { get; set; }

    //Doctors working in the hospital
    public List<DoctorEntity> Doctors { get; set; }

    // Global admin
    public Guid GlobalAdminId { get; set; }

    // Administrator of hospital
    public HospitalAdminEntity HospitalAdmin { get; set; }
}