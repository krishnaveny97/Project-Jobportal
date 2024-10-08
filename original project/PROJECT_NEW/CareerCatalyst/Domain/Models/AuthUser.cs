﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AuthUser
{
    public Guid Id { get; set; }= Guid.NewGuid();

    public string? Password { get; set; }

    public string? UserName { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Enum.Role Role { get; set; }

    public string? ConnectionId { get; set; }

    public bool? OnlineStatus { get; set; }
}
