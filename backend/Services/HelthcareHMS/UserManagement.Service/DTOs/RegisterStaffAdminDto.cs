﻿namespace UserManagement.Service.DTOs;

public class RegisterStaffAdminDto
{
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public Guid CreatedByGlobalAdminId { get; set; } 
}