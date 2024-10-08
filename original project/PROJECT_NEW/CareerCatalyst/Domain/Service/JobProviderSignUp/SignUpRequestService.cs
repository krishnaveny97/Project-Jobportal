using AutoMapper.Internal;
using AutoMapper;
using Domain.Models;
using Domain.Service.JobProviderSignUp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service.JobProviderSignUp;
using Domain.Service.JobProviderSignUp.DTO;
using Domain.Helpers;
using Domain.Enums;
using Domain.Service.AuthUser.Interfaces;

namespace Domain.Service.JobProviderSignUp
{
    public class SignUpRequestService:ISignUpRequestService
    {
        private readonly IMapper _mapper;
        private readonly ISignUpRequestRepository _signuprepository;
        private readonly IMailService _emailservice;
        private readonly IAuthRepository _authRepository;
        public SignUpRequestService(IMapper mapper, ISignUpRequestRepository signuprepository, IMailService emailservice, IAuthRepository authRepository)
        {
            _mapper = mapper;
            _signuprepository= signuprepository;
            _emailservice= emailservice;
            _authRepository= authRepository;
        }
        public async void CreateSignupRequest(JobProviderSignUpRequestDto data)
        {

            var signUpRequest = _mapper.Map<SignUpRequest>(data);
            var signUpId = _signuprepository.AddSignUp(signUpRequest);
            MailRequest mailRequest = new MailRequest();
            mailRequest.Subject = "HireMeNow SignUp Verification";
            mailRequest.Body = "http://localhost:4200/set-password?signupid=" + signUpId.ToString();
            mailRequest.ToEmail = signUpRequest.Email;
            await _emailservice.SendEmailAsync(mailRequest);
        }
        public async Task<bool> VerifyEmailAsync(Guid jobProviderSignupRequestId)
        {

            SignUpRequest signUpRequest = await _signuprepository.GetSignupRequestByIdAsync(jobProviderSignupRequestId);
            if (signUpRequest != null)
            {
                signUpRequest.Status = (int)Enums.Status.Verified;
                _signuprepository.UpdateSignupRequest(signUpRequest);
                return true;
            }
            return false;
        }
        public async Task CreateJobProvider(Guid jobSeekerSignupRequestId, string password)
        {
            try
            {
                SignUpRequest signUpRequest = await _signuprepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);
                
                Domain.Models.AuthUser authUser = new();
                if (signUpRequest.Status ==(int) Enums.Status.Verified)
                {
                    //need to change this code by using Automapper 

                     authUser = _mapper.Map<Domain.Models.AuthUser>(signUpRequest);
                    authUser.Password = password;
                    //authUser.UserName = signUpRequest.UserName;
                    //authUser.Role =(int) Enum.Role.JOB_PROVIDER;
                    //authUser.FirstName = signUpRequest.FirstName;
                    //authUser.LastName = signUpRequest.LastName;
                    //authUser.Email = signUpRequest.Email;

                    //authUser.Phone = signUpRequest.Phone;
                    authUser = await _authRepository.AddAuthUser(authUser);
                    signUpRequest.Status =(int) Enums.Status.Created;
                    _signuprepository.UpdateSignupRequest(signUpRequest);
                }

                Models.CompanyUser jobprovider = _mapper.Map<Models.CompanyUser>(authUser);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
