using Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using CareerCatalyst.API.JobProvider;
using CareerCatalyst.API.JobProvider.RequestObjects;
using Domain.Service.AuthUser.Interfaces;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.JobProvider;
using Domain.Service.JobProvider.Interface;
using Domain.Helpers;

namespace CareerCatalyst.API.JobProvider
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize(Roles ="JOB_PROVIDER")]
    public class CompanyController : ControllerBase
    {
        private readonly IAuthService _AuthService;
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        public CompanyController(IAuthService AuthService, IMapper mapper, ICompanyService companyService)
        {
            _AuthService= AuthService;
            _mapper=    mapper;
            _companyService= companyService;
        }


        
        [HttpPost]
        [Route("job-provider/{jobproviderId}/company")]

        public async Task<ActionResult> AddCompany(Guid jobproviderId, AddCompanyRequestObject data)
        {
            var UserId = _AuthService.GetUserId();
            var companyRegistrationDtos = _mapper.Map<CompanyRegistrationDto>(data);

            var company = await _companyService.AddCompany(companyRegistrationDtos, jobproviderId);
            return Ok(company);

        }
        [AllowAnonymous]
        [HttpGet]
        [Route("job-provider/company/{companyId}")]
        public async Task<ActionResult> getCompany(Guid companyId)
        {
            var company = _companyService.GetCompany(companyId);
            if (company == null)
            {
                return BadRequest("Company Not found");

            }
            else
            {
                return Ok(company);
            }


        }
        [AllowAnonymous]
        [HttpPut]
        [Route("job-provider/company/{companyId}")]
        public async Task<ActionResult> UpdateCompany(Guid companyId, CompanyUpdateRequest comapny)
        {
            if (companyId == null)
            {
                return BadRequest("Id is Required");
            }
            comapny.Id = companyId;
            var companyUpdateDtos = _mapper.Map<CompanyUpdateDtos>(comapny);
            var updatedCompany = await _companyService.UpdateAsync(companyUpdateDtos);
            //CompanyupdateRequest companyupdateRequest = mapper.Map<CompanyupdateRequest>(updatedCompany);
            if (updatedCompany == null)
            {
                return BadRequest("Company Not found");

            }
            else
            {
                return Ok(updatedCompany);
            }

        }
    
    //Add-Company-Member

        [AllowAnonymous]
        [HttpPost]
        [Route("job-provider/company/{companyId}/addcompanymember")]
        public async Task<ActionResult> AddCompanyMember(CompanyUserRequest request, Guid companyId)
        {
            try
            {
                var companyMemberDtos = _mapper.Map<CompanyMemberDtos>(request);
                var member = await _companyService.addMember(companyMemberDtos, companyId);
                return Ok(member);
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("job-provider/company/{companyId}/listcompanymember")]
        public async Task<ActionResult> ListCompanyMember(Guid companyId, [FromQuery] CompanyMamberListParams param)

        {

            if (companyId == null)
            {
                return BadRequest("Id is Required");
            }

            var CompanyMembers = await _companyService.memberListing(companyId, param);

            PagedList<CompanyMemberListDto> companyMemberList = _mapper.Map<PagedList<CompanyMemberListDto>>(CompanyMembers);
            if (CompanyMembers == null)
            {
                return BadRequest("No Company Members");

            }
            else
            {
                return Ok(CompanyMembers);
            }

        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("job-provider/company/{companyMemberId}/RemoveCompanyMember")]
        public IActionResult memberDelete(Guid companyMemberId)
        {
            var result = _companyService.memberDeleteById(companyMemberId);
            if (result == true)
            {
                return Ok("Success fully remove the companyMember");

            }
            else
            {
                return BadRequest();
            }
        }


    }
}
