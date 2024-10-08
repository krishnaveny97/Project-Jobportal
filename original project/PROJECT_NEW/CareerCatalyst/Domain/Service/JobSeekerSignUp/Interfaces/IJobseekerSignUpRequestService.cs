using Domain.Service.JobSeekerSignUp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobSeekerSignUp.Interfaces
{
    public interface IJobseekerSignUpRequestService
    {
        void CreateSignupRequest(JobSeekerSignupRequestDto data);
        Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId);
        Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password);
    }
}
