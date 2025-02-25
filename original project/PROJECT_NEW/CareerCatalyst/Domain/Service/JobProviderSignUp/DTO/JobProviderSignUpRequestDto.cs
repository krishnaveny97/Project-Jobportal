﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProviderSignUp.DTO
{
    public class JobProviderSignUpRequestDto
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
    }
}
