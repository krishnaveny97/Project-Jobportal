using System.ComponentModel.DataAnnotations;

namespace CareerCatalyst.API.JobSeeker.RequestObjectsDtos
{
    public class JobSeekerLoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
