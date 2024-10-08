using AutoMapper;
using CareerCatalyst.API.JobSeeker.RequestObjectsDtos;
using Domain.Models;
using Domain.Service.Authuser.DTOs;
using Domain.Service.Profile.DTOs;
using Domain.Service.Profile.Interface;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CareerCatalyst.API.JobSeeker
{

    //[ApiController]
    [Authorize(Roles = "JOB_SEEKER")]
    //[Route("api/[controller]")]
    [ApiController]
    public class JobSeekerProfileController : BaseApiController<JobseekerController>
    { 
        IMapper _mapper;
        public readonly IJobSeekerProfileService _profileService;

        public JobSeekerProfileController(IMapper mapper, IJobSeekerProfileService profileService)
        {
            _mapper = mapper;
            _profileService = profileService;
        }

        //Adding Qualification

        [HttpPost]
        [Route("{jobseekerId}/profile/{profileId}/Qualification")]
        public async Task<ActionResult> AddQualificationToProfile(Guid jobseekerId, Guid profileId, QualificationRequestDto data)
        {
            try
            {
                var JobseekerQualificationDTo = _mapper.Map<JobseekerQualificationDTo>(data);
                 var qualification=await _profileService.AddQualificationToProfileAsync(jobseekerId, profileId, JobseekerQualificationDTo);
                return Ok(qualification);

            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add Qualification: " + ex.Message);

            }

        }

        //Get qualification of jobseeker base on jobseekerProfile id

        [HttpGet]
        [Route("profile/{profileId}/Qualification")]
        public ActionResult<List<JobseekerQualificationDTo>> GetQualification(Guid profileId)
        {
            var Qualification = _profileService.GetQualification(profileId);

            if (Qualification == null )
                return NotFound();

            return Ok(Qualification);

        }

        //Adding Experience

        [HttpPost]
        [Route("{jobseekerId}/profile/{profileId}/Experience")]
        public async Task<ActionResult> AddQualificationToProfile(Guid jobseekerId, Guid profileId, WorkExperieceRequestDto data)
        {
            try
            {
                var JobseekerexperienceDTo = _mapper.Map<JobseekerWorkExperienceDTo>(data);
                await _profileService.AddWorkExpericeToProfileAsync(jobseekerId, profileId, JobseekerexperienceDTo);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add Experience:" + ex.Message);

            }

        }
        //Getting Experince Based on Jobseekerprofile id
        [HttpGet]
        [Route("profile/{profileId}/Experience")]
        public ActionResult<List<JobseekerWorkExperienceDTo>> GetExperience(Guid profileId)
        {
            var experinces = _profileService.GetExperience(profileId);
            if (experinces == null)
                return NotFound();
            return Ok(experinces);

        }

        //Adding Skills
        
        [HttpPost("{jobSeekerId}/Skills")]
        public async Task<IActionResult> AddSkillsToProfile(Guid jobSeekerProfileId, List<Guid> skillIds)
        {
            try
            {
               
                await _profileService.AddSkillAsync( jobSeekerProfileId, skillIds);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add skill: " + ex.Message);
            }
        }


        //Get Skill based on Jobseeker profile id
        [HttpGet("{profileId}/skills")]
        public async Task<IActionResult> GetSkillsByProfileId(Guid profileId)
        {
            try
            {
                var skills = await _profileService.GetSkillsByProfileIdAsync(profileId);
                if (skills == null )
                {
                    return NotFound();
                }
                return Ok(skills);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get skills: " + ex.Message);
            }
        }


        //Get SKills details
        [HttpGet]
        [AllowAnonymous]
        [Route("skills")]
        public ActionResult<List<JobSeekerSkillDto>> GetSkills()
        {
            var skills = _profileService.GetSkillsForJobSeekerProfile();

            if (skills == null )
                return NotFound();

            return Ok(skills);
        }



        //Jobseeker profile detail based on jobseeker id
        [HttpGet("{jobseekerId}/profiledetails")]
        public ActionResult<List<JobSeekerProfileDTo>> GetProfile(Guid jobseekerId)
        {

            var Profile = _profileService.GetJobSeekerProfiles(jobseekerId);
            if (Profile == null )
                return NotFound();

            return Ok(Profile);
        }


        //Update whole detaitails of Jobseeker Profile

        //[HttpPut("UpdateJobSeekerProfile")]
        //public async Task<IActionResult> UpdateJobSeekerProfile([FromForm] AuthUserDTO updatedProfile)
        //{
        //    try
        //    {
        //        var result = await _profileService.UpdateJobSeekerProfileAsync(updatedProfile);

        //        if (result != null)
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();
        //    }

        //    catch (Exception ex)
        //    {
        //        return BadRequest("Failed to Update JobSekkere Profile: " + ex.Message);
        //    }


        //}



        //[HttpPatch("JobSeekerProfileUpdate")]

        //public async Task<IActionResult> UpdateJobSeekerProfile([FromForm] AuthUserDTO updatedProfile)
        //{
        //    try
        //    {
        //        var result = await _profileService.UpdateJobSeekerProfileAsync(updatedProfile);

        //        if (result != null)
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();
        //    }

        //    catch (Exception ex)
        //    {
        //        return BadRequest("Failed to Update JobSekkere Profile: " + ex.Message);
        //    }


        //}

        //Add Profile
        [HttpPost("{JobseekerId}/AddProfile")]
        public async Task<IActionResult> AddProfile(Guid JobseekerId ,JobSeekerProfileRequestDto profile)
        {
            if (profile == null)
            {
                return BadRequest("Profile data is required.");
            }

            try
            {
                var profileDto = _mapper.Map<ProfileDTO>(profile);
                var result = await _profileService.AddProfile(JobseekerId,profileDto);
                if (result)
                {
                    return Ok("Profile added successfully.");
                }
                else
                {
                    return BadRequest("Failed to add profile.");
                }
            }
            catch (Exception ex)
            {
                // Return detailed error message for debugging
                return StatusCode(500, $"Internal server error: {ex.Message} - {ex.InnerException?.Message}");
            }
        }


        //Get whole Jobseeker Profile
        //[HttpGet("compleateprofile")]
        //public ActionResult<List<JobSeekerProfileDTo>> GetAllProfile()
        //{
        //    try
        //    {
        //        var profiles = _profileService.GetProfiles();
        //        if (profiles == null )
        //            return NotFound();
        //        return Ok(profiles);
        //    }
        //    catch (Exception ex) 
        //    {
        //        // Handle exceptions and log errors
        //        return StatusCode(500, ex.Message);
        //    }




        //}
    }
}
