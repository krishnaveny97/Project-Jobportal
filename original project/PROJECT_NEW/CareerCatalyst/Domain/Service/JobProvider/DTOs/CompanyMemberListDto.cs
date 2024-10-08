﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.DTOs
{
    public class CompanyMemberListDto
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }

        public Enum.Role Role { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
