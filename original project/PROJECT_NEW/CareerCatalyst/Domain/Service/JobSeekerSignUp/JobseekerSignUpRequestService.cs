using AutoMapper;
using AutoMapper.Internal;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Authuser;
using Domain.Service.Authuser.Interfaces;
using Domain.Service.JobSeekerSignUp.DTOs;
using Domain.Service.JobSeekerSignUp.Interfaces;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobSeekerSignUp
{
    public class JobseekerSignUpRequestService : IJobseekerSignUpRequestService
    {
        IMapper mapper;
        public IJobseekerSignUpRequestRepository jobSeekerrepository;
        public IMailService mailService;
        IAuthUserRepository _authuserRepository;
        public JobseekerSignUpRequestService(IMapper _mapper, IJobseekerSignUpRequestRepository _jobSeekerrepository, IMailService _mailService,IAuthUserRepository authUserRepository)
        {
            mapper = _mapper;
            jobSeekerrepository = _jobSeekerrepository;
            mailService = _mailService;
            _authuserRepository = authUserRepository;



        }
        public async void CreateSignupRequest(JobSeekerSignupRequestDto data)
        {
            var signUpRequest = mapper.Map<SignUpRequest>(data);
            var signUpId = jobSeekerrepository.AddSignupRequest(signUpRequest);
            MailRequest mailRequest = new MailRequest();
            mailRequest.Subject = "HireMeNow SignUp Verification";
            mailRequest.Body = "http://localhost:4200/set-password?signupid=" + signUpId.ToString();
            mailRequest.ToEmail = signUpRequest.Email;
            await mailService.SendEmailAsync(mailRequest);


        }
        public async Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId)
        {
            SignUpRequest signUpRequest=await jobSeekerrepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);
            if(signUpRequest != null)
            {
                signUpRequest.Status = (int)Enums.Status.Verified;
                jobSeekerrepository.UpdateSignupRequest(signUpRequest);
                return true;

            }
            return false;

        }

        //Get jobseeker who is authuser
        public async Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password)
        {
            try
            {
                SignUpRequest signUpRequest = await jobSeekerrepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);
                Domain.Models.AuthUser authUser = new();
                if ((Enums.Status)signUpRequest.Status == Enums.Status.Verified)
                {
                    authUser.UserName = signUpRequest.UserName;
                    authUser.Role = Enum.Role.JOB_SEEKER;
                    authUser.FirstName = signUpRequest.FirstName;
                    authUser.LastName = signUpRequest.LastName;
                    authUser.Email = signUpRequest.Email;
                    authUser.Password = password;
                    authUser.Phone = signUpRequest.Phone;
                    authUser=await _authuserRepository.AddAuthUser(authUser);
                    signUpRequest.Status = (int)Enums.Status.Created;
                    jobSeekerrepository.UpdateSignupRequest(signUpRequest);


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
