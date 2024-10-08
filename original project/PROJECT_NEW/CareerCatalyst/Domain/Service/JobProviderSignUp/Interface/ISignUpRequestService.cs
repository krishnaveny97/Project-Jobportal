using Domain.Service.JobProviderSignUp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProviderSignUp.Interface
{
    public interface ISignUpRequestService
    {
        void CreateSignupRequest(JobProviderSignUpRequestDto data);
        Task<bool> VerifyEmailAsync(Guid jobProviderSignupRequestId);
        Task CreateJobProvider(Guid jobProviderSignupRequestId, string password);
    }
}
