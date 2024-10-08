using AutoMapper;
using CareerCatalyst.API.JobSeeker.RequestObjectsDtos;
using Domain.Service.JobSeekerSignUp.DTOs;
using Domain.Service.JobSeekerSignUp.Interfaces;
using Domain.Service.Login;
using Domain.Service.Login.DTOs;
//using Domain.Service.Login.Interface;
using Domain.Service.Login.Interfaces;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCatalyst.API.JobSeeker
{
   
    [ApiController]
    public class JobseekerController : BaseApiController<JobseekerController>
    {
        IMapper _mapper;
        public  IJobseekerSignUpRequestService _jobSeekerService;
        public ILoginRequestService _loginService;
        public JobseekerController(IMapper mapper, IJobseekerSignUpRequestService jobSeekerService,ILoginRequestService loginService)
        {
            _mapper = mapper;
            _jobSeekerService = jobSeekerService;
            _loginService = loginService;
        }
        // when credential provide job seeker sign up an email is send to the mail

        [HttpPost]
        [Route("Job-Seeker/Signup")]
        public async Task<ActionResult> createJobSeekerSignupRequest(JobSeekerSignuprequestDto data)
        {
            var jobSeekerSignupRequestDto = _mapper.Map<JobSeekerSignupRequestDto>(data);
            _jobSeekerService.CreateSignupRequest(jobSeekerSignupRequestDto);
            return Ok(data);

        }
        //verifying email id using jobseeker signuprequest id

        [HttpGet]
        [Route("Job-Seeker/SignUp/{JobseekersignupRequestId}/Verfy-Email")]
        public async Task<ActionResult> VerifyJobSeekerEmail(Guid JobseekersignupRequestId)
        {
            var isVerified=await _jobSeekerService.VerifyEmailAsync(JobseekersignupRequestId);
            if(isVerified)
            {
                return Ok();
            }
            return BadRequest();

        }

        //setting password to the jobseeker who is signed

        [HttpPost]
        [Route("Job-Seeker/{JobseekersignupRequestId}/set-password")]
        public async Task<ActionResult> createJobSeekerSignupRequest(Guid JobseekersignupRequestId, [FromBody] string password)
        {
            await _jobSeekerService.CreateJobseeker(JobseekersignupRequestId, password);
            return Ok("Password Set Successfully");
        
        }

        [HttpPost]
        [Route("job-seeker/Login")]
        public async Task<ActionResult> Login(JobSeekerLoginRequestDto logdata)
        {

            var user = _loginService.login(logdata.Email, logdata.Password);
            if (user == null)
            {
                return BadRequest("Login failed");
            }
            return Ok(user);

        }
        }
}
