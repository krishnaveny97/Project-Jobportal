using Domain.Enums;
using Domain.Models;
using Domain.Service.JobSeekerSignUp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobSeekerSignUp
{
    public class JobseekerSignUpRequestRepository:IJobseekerSignUpRequestRepository
    {
        public NewDbContext _context;
        public JobseekerSignUpRequestRepository(NewDbContext context) 
        {
            _context = context;
        
        }
        public Guid AddSignupRequest(SignUpRequest signUpRequest)
        {
            signUpRequest.Id = Guid.NewGuid();
            signUpRequest.Status= (int)Status.Pending;
            _context.SignUpRequests.AddAsync(signUpRequest);
            _context.SaveChanges();
            return signUpRequest.Id;
            

        }
        public async Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobSeekerSignupRequestId)
        {
            return await _context.FindAsync<SignUpRequest>(jobSeekerSignupRequestId);
        }
        public void UpdateSignupRequest(SignUpRequest signUpRequest)
        {
            _context.SignUpRequests.Update(signUpRequest);
            _context.SaveChanges();
        }
    }
}
