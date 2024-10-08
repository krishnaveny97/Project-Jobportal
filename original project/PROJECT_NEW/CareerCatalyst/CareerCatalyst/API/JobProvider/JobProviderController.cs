using AutoMapper;
using CareerCatalyst.API.JobProvider.RequestObjects;
using Domain.Models;
using Domain.Service.JobProvider.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCatalyst.API.JobProvider
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobProviderController : ControllerBase
    {
        public readonly IMapper _mapper;
        public JobProviderController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("company/job-provider/job")]
        public async Task<IActionResult> PostJob(JobPostRequest obj)
        {
            try
            {
                var job = _mapper.Map<JobPost>(obj);
                // Guid id = await _jobProviderService.PostJob(job);
                // return Ok("The job id for the posted job is" + id);
                return Ok(job);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
