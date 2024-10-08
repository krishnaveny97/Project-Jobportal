using Domain.Models;
using Domain.Service.JobProviderSignUp.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProviderSignUp
{
    public class SignUpRequestRepository:ISignUpRequestRepository
    {
        private readonly NewDbContext _context;
        public SignUpRequestRepository(NewDbContext context)
        {
            _context=context;
        }
        public Guid AddSignUp(SignUpRequest request)
        {
            try
            {
                request.Id= Guid.NewGuid();
                request.Status = (int)Enums.Status.Pending;
                _context.SignUpRequests.Add(request);
                _context.SaveChanges();
                return request.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobProviderSignupRequestId)
        {
            return await _context.SignUpRequests.FindAsync(jobProviderSignupRequestId);
        }

        public void UpdateSignupRequest(SignUpRequest signUpRequest)
        {
            _context.SignUpRequests.Update(signUpRequest);
            _context.SaveChanges();
        }
    }
}
