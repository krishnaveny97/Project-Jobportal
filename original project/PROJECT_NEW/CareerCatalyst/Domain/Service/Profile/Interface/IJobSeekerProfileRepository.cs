using Domain.Models;
using Domain.Service.Authuser.DTOs;
using Domain.Service.Profile.DTOs;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Profile.Interface
{
    public interface IJobSeekerProfileRepository
    {
        //qualification
        Task<JobSeekerProfile?> GetJobSeekerProfileByIds(Guid jobseekerId, Guid profileId);
        Task<Qualification> AddQualificationsToProfileAsync(Guid profileId, Qualification qualification);
        List<Qualification> GetQualification(Guid profileId);

        //work experince
        Task<WorkExperience> AddWorkExperienceToProfileAsync(Guid profileId, WorkExperience experience);
        List<WorkExperience> GetExperience(Guid profileId);

        //Skills
        Task AddSkillsToProfileAsync(Guid jobSeekerProfileId, List<Guid> skillIds);

        Task<List<Skill>> GetSkillsByProfileIdAsync(Guid profileId);
        //Task<Skill> GetSkillByIdAsync(Guid skillId);


        //Get Skill Details
        List<Skill> GetSkills();


        //Get Jobseeker Profile based on Jobseeker Id

        // Task<JobSeekerProfile> GetProfileAsync(Guid jobseekerId, Guid profileId);


        public List<JobSeekerProfileDTo> GetProfile(Guid jobseekerId);


        //Update Jobseeker Whole Details
        // Task<AuthUser> GetUserByIdAsync(Guid userId);
        // Task UpdateUserAsync(AuthUser user);

        //Add Jobseeker Profile
        Task AddProfile(Guid JobseekerId, JobSeekerProfile jobSeekerProfile);


        //Get whole Jobseekerprofile 
        //List<Domain.Models.Profile> Getprofiles();
       

    }

}
