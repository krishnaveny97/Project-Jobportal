using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProviderSignUp.Interface
{
    public interface ISignUpRequestRepository
    {
        Guid AddSignUp(SignUpRequest request);
        Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobProviderSignupRequestId);
        void UpdateSignupRequest(SignUpRequest signUpRequest);
    }
}
