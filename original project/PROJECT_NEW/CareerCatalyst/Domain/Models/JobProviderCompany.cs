﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class JobProviderCompany
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string LegalName { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public Guid IndustryId { get; set; }

    public string Email { get; set; } = null!;

    public long Phone { get; set; }

    public string Address { get; set; } = null!;

    public string Website { get; set; } = null!;

    public Guid Location { get; set; }

    public virtual ICollection<CompanyUser> CompanyUsers { get; set; } = new List<CompanyUser>();

    public virtual Industry Industry { get; set; } = null!;

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual Location LocationNavigation { get; set; } = null!;
}
