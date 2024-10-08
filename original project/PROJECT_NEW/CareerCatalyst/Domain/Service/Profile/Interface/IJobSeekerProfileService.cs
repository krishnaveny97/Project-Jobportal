using Domain.Models;
using Domain.Service.Authuser.DTOs;
using Domain.Service.Profile.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Profile.Interface
{
    public interface IJobSeekerProfileService
    {
        //Qualification
        Task<Qualification> AddQualificationToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerQualificationDTo jobseekerQualificationDTo);
        List<JobseekerQualificationDTo> GetQualification(Guid profileId);

        //Work experince
        Task<WorkExperience> AddWorkExpericeToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerWorkExperienceDTo data);
        List<JobseekerWorkExperienceDTo> GetExperience(Guid profileId);

        //Skills
        Task AddSkillAsync(Guid jobSeekerProfileId, List<Guid> skillIds);
        Task<List<JobSeekerSkillDto>> GetSkillsByProfileIdAsync(Guid profileId);

        //Get Skill Details
        List<JobSeekerSkillDto> GetSkillsForJobSeekerProfile();


        //get Jobseeker Profile based on Jobseeker Id
        List<JobSeekerProfileDTo> GetJobSeekerProfiles(Guid jobseekerId);

        //Update Whole Details of jobseeker
        //Task<AuthUser> UpdateJobSeekerProfileAsync(AuthUserDTO userDto);

        //Add Jobseeker Profile
        Task<bool> AddProfile( Guid JobseekerId,ProfileDTO profileDto);


        //Get Jobseekerprofile based on jobseeker id
        //List<JobSeekerProfileDTo> GetProfiles();
    }
}
