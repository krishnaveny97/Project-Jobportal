using AutoMapper;
using CareerCatalyst.API.JobProvider.RequestObjects;
using Domain.Models;
using Domain.Service.AuthUser.Interfaces;
using Domain.Service.JobProvider;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.JobProvider.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Helpers;

namespace CareerCatalyst.API.JobProvider
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "COMPANY_USER")]
    public class InterviewController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IInterviewService _interviewServices;
        private readonly IAuthService _authService;
        public InterviewController(IMapper mapper, IInterviewService interviewServices, IAuthService authService)
        {
            _mapper=mapper;
            _interviewServices=interviewServices;
            _authService=authService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("company/company-user/{companyuserid}/Interview")]

        public async Task<ActionResult> SheduleInterview(InterviewSheduleObject interviewSheduleObject, Guid companyuserid)
        {
            var user = _authService.GetUser(companyuserid);
            if (user == null)
            {
                return BadRequest("No User");
            }

            var interviewDto = _mapper.Map<InterviewSheduleDto>(interviewSheduleObject);

            Interview interview = _interviewServices.sheduleinterview(interviewDto, user);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("company/company-user/{companyid}/Interviewlist")]
        public  ActionResult SheduledInterviewList(Guid companyid)
        {
            //var user = authUserService.GetUser(companyuserid);
            //if (user == null)
            //{
            //    return BadRequest("No User");
            //}
            List<Interview> sheduledinterview =  _interviewServices.sheduledInterviewList(companyid);
           // Response.AddPaginationHeader(sheduledinterview.CurrentPage, sheduledinterview.PageSize, sheduledinterview.TotalCount, sheduledinterview.TotalPages);
            var sheduledinerviewDto = _mapper.Map<List<SheduledInterviewList>>(sheduledinterview);
            if (sheduledinerviewDto == null)
            {
                return BadRequest("No Interview");
            }
            else
            {
                return Ok(sheduledinerviewDto);
            }



        }
        [AllowAnonymous]
        [HttpDelete]
        [Route("company/company-user/{intererviewid}/cancel")]
        public async Task<ActionResult> cancelInterview(Guid intererviewid)
        {
            var result = _interviewServices.removeInterview(intererviewid);
            if (result == true)
            {
                return Ok("Successfully cancel the interview");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
