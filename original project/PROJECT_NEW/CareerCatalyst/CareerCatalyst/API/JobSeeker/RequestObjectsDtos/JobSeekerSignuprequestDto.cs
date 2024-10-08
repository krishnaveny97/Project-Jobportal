using System.ComponentModel.DataAnnotations;

namespace CareerCatalyst.API.JobSeeker.RequestObjectsDtos
{
    public class JobSeekerSignuprequestDto
    {
        public Guid jobSeekerSignupRequestId { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
