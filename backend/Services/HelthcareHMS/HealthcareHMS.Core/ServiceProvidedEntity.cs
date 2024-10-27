﻿namespace HealthcareHMS.Core;

public class ServiceProvidedEntity
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public string ServiceName { get; set; }
    
    public DoctorEntity Doctor { get; set; }    
}