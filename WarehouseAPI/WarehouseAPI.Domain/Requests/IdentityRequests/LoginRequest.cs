﻿namespace WarehouseAPI.Domain.Requests.IdentityRequests;

public class LoginRequest
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}