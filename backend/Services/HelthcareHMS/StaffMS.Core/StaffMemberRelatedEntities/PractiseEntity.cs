﻿namespace StaffMS.Core;

public class PractiseEntity
{
    public Guid Id { get; set; }
    public Guid StaffId { get; set; }
    public string Practise { get; set; }
    
    public StaffMemberEntity StaffMember { get; set; }
}