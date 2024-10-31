﻿using StaffMS.WebAPI.Domain.UserRelated;

namespace StaffMS.WebAPI.Domain.Additional;

public class LicenseEntity
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public string License { get; set; }
    
    public StaffMemberEntity StaffMember { get; set; }
}