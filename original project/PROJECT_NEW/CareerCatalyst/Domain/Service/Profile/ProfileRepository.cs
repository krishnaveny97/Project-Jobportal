using AutoMapper;
using Domain.Models;
using Domain.Service.Authuser.DTOs;
using Domain.Service.Profile.DTOs;
using Domain.Service.Profile.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Service.Profile
{
    public class ProfileRepository : IJobSeekerProfileRepository
    {
        public readonly NewDbContext _Context;
        public ProfileRepository(NewDbContext context)
        {
            _Context = context;

        }

        //Getting Jobseeker profile based on jobseeker id
        public Task<JobSeekerProfile?> GetJobSeekerProfileByIds(Guid jobseekerId, Guid profileId)
        {
            return _Context.JobSeekerProfiles.FirstOrDefaultAsync(profile => profile.JobSeekerId == jobseekerId && profile.Id == profileId);

        }

        //Adding qualification to profile
        public async Task<Qualification> AddQualificationsToProfileAsync(Guid profileId, Qualification qualification)
        {
            try
            {

                qualification.JobseekerProfileId = profileId;
                await _Context.Qualifications.AddAsync(qualification);
                await _Context.SaveChangesAsync();
                return qualification;

            }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //Get qualification baser on jobseekerprofileid
        public List<Qualification> GetQualification(Guid profileId)
        {
            return _Context.Qualifications
                .Where(qualification => qualification.JobseekerProfileId == profileId).ToList();
        }

        //Adding WorkExperince to Profile
        public async Task<WorkExperience> AddWorkExperienceToProfileAsync(Guid profileId, WorkExperience experience)
        {
            try
            {
                experience.JobSeekerProfileId = profileId;
                // experience.Id = Guid.NewGuid();
                await _Context.WorkExperiences.AddAsync(experience);
                await _Context.SaveChangesAsync();
                return experience;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        //Gettin Work Expericence based on Jobseeker ProfileId
        public List<WorkExperience> GetExperience(Guid profileId)
        {
            try
            {
                return _Context.WorkExperiences
                    .Where(workexperience => workexperience.JobSeekerProfileId == profileId).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        //Adding Skills to Profile

        public async Task AddSkillsToProfileAsync(Guid jobSeekerProfileId, List<Guid> skillIds)
        {
            // Fetch the JobSeekerProfile by ID
            var profile = await _Context.JobSeekerProfiles
                .FirstOrDefaultAsync(p => p.JobSeekerId == jobSeekerProfileId);

            if (profile == null)
            {
                throw new Exception("Profile not found");
            }

            // Create JobSeekerProfileSkill entries for each skill
            var newSkills = skillIds.Select(skillId => new JobSeekerProfileSkill
            {
                JobSeekerProfileId = profile.Id,
                SkillId = skillId
            }).ToList();


            foreach (var item in newSkills)
            {
                await _Context.JobSeekerProfileSkills.AddAsync(item);

            }
            await _Context.SaveChangesAsync();

        }


        //retreiving skills based on Jobseeker profile Id
        public async Task<List<Skill>> GetSkillsByProfileIdAsync(Guid profileId)
        {
            return await _Context.JobSeekerProfileSkills
                .Where(profile => profile.JobSeekerProfileId == profileId)
                .Select(profile => profile.Skill)
                .ToListAsync();
        }




        //Get Skill Details
        public List<Skill> GetSkills()
        {
            return _Context.Skills.ToList();
        }

        //Get Jobseekr profile based on jobseeker id
        public List<JobSeekerProfileDTo> GetProfile(Guid jobseekerId)
        {
            var jobSeekerProfile = 
                _Context.JobSeekerProfiles
                .Where(e=>e.JobSeekerId==jobseekerId)
              
                .ToList();



            if (jobSeekerProfile == null)
            {
                // Handle case when the profile is not found
                return new List<JobSeekerProfileDTo>(); // or return null, depending on your handling
            }
            var jobSeekerProfileDTO = new JobSeekerProfileDTo();
            //var jobSeekerProfileDTO = jobSeekerProfile.Select(e => new JobSeekerProfileDTo
            //{
            //    UserName = e.JobSeeker.UserName,
            //    FirstName = e.JobSeeker.FirstName,
            //    LastName = e.JobSeeker.LastName,
            //    Phone = e.JobSeeker.Phone,
            //    Email = e.JobSeeker.Email,
            //    image = e.JobSeeker.Image,

            //    Role = e.JobSeeker.Role
            //}).ToList();
            //Qualifications = e.Qualifications?.Select(q => new JobseekerQualificationDTo
            //{
            //    Name = q?.Name,
            //    Description = q?.Description,
            //}).ToList();


            return new List<JobSeekerProfileDTo> { jobSeekerProfileDTO};
            //public async Task<AuthUser> GetUserByIdAsync(Guid userId)
            //{
            //    return await _Context.AuthUsers.FindAsync(userId);
            //}

            //public async Task UpdateUserAsync(AuthUser user)
            //{
            //    _Context.Entry(user).State = EntityState.Modified;
            //    await _Context.SaveChangesAsync();
            //}
        }

            //Add Jobseeker Profile
            public async Task AddProfile(Guid JobseekerId, JobSeekerProfile jobSeekerProfile)
            {

            //try
            //{
            //    if (jobSeekerProfile.Id == Guid.Empty)
            //    {
            //        jobSeekerProfile.Id = Guid.NewGuid();
            //    }

            //    jobSeekerProfile.JobSeekerId = JobseekerId;
            //    await _Context.JobSeekerProfiles.AddAsync(jobSeekerProfile);
            //    await _Context.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    // Log or handle exception
            //    throw new Exception($"An error occurred while saving the entity: {ex.Message}", ex);
            //}


            try
            {
                var existingProfile = await _Context.JobSeekerProfiles
                    .FirstOrDefaultAsync(profile => profile.JobSeekerId == JobseekerId);

                if (existingProfile != null)
                {
                    // Update existing profile
                    existingProfile.ProfileName = jobSeekerProfile.ProfileName;
                    existingProfile.ProfileSummary = jobSeekerProfile.ProfileSummary;
                    // Update other fields as necessary

                    _Context.JobSeekerProfiles.Update(existingProfile);
                }
                else
                {
                    // Add new profile
                    if (jobSeekerProfile.Id == Guid.Empty)
                    {
                        jobSeekerProfile.Id = Guid.NewGuid();
                    }

                    jobSeekerProfile.JobSeekerId = JobseekerId;
                    await _Context.JobSeekerProfiles.AddAsync(jobSeekerProfile);
                }

                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle exception
                throw new Exception($"An error occurred while saving the entity: {ex.Message}", ex);
            }
        }

            //Get whole  Jobseeker profile 

            //public List<Domain.Models.Profile> Getprofiles()
            //{
            //    return _Context.Profiles.ToList();

            //}
        }
    }

