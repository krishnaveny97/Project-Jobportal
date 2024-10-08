using AutoMapper;
using Domain.Models;
using Domain.Service.Authuser.DTOs;
using Domain.Service.Profile.DTOs;
using Domain.Service.Profile.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Profile
{
    public class ProfileService : IJobSeekerProfileService
    {
        public readonly IJobSeekerProfileRepository _profileRepository;
        IMapper _mapper;
        public ProfileService(IJobSeekerProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;

        }
        //If Jobseeker id not null then qualification adding to the profile
        public async Task<Qualification> AddQualificationToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerQualificationDTo jobseekerQualificationDTo)
        {

            var profile =await _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            if (profile != null)
            {
                var Qualification = _mapper.Map<Qualification>(jobseekerQualificationDTo);
                return await _profileRepository.AddQualificationsToProfileAsync(profileId, Qualification);

            }
            else
            {
                throw new Exception("Profile not found");
            }

        }
        //Getting qualification based on jobseeker id
        public List<JobseekerQualificationDTo> GetQualification(Guid profileId)
        {
            var Qualifications = _profileRepository.GetQualification(profileId);
            var QualificationDtos = _mapper.Map<List<JobseekerQualificationDTo>>(Qualifications);

            return QualificationDtos;

        }


        //If Jobseeker id not null then Experince adding to the profile
        public async Task<WorkExperience> AddWorkExpericeToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerWorkExperienceDTo data)
        {

            var profile =await  _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            if (profile != null)
            {
                var Experience = _mapper.Map<WorkExperience>(data);
                return await _profileRepository.AddWorkExperienceToProfileAsync(profileId, Experience);

            }
            else
            {
                throw new Exception("Profile not found");
            }

        }

        //Getting Experince based on Profile Id
        public List<JobseekerWorkExperienceDTo> GetExperience(Guid profileId)
        {
            var experience = _profileRepository.GetExperience(profileId);
            var experienceDto = _mapper.Map<List<JobseekerWorkExperienceDTo>>(experience);
            return experienceDto;
        }

        //Adding Skills to Profile
        public async Task AddSkillAsync(Guid jobSeekerProfileId, List<Guid> skillIds)
        {
            
            await _profileRepository.AddSkillsToProfileAsync(jobSeekerProfileId, skillIds);
        }

        //get skill based on Jobseeker profile Id
        public async Task<List<JobSeekerSkillDto>> GetSkillsByProfileIdAsync(Guid profileId)
        {
            var skills = await _profileRepository.GetSkillsByProfileIdAsync(profileId);
            return _mapper.Map<List<JobSeekerSkillDto>>(skills);
        }

        //Get skill details
        public List<JobSeekerSkillDto> GetSkillsForJobSeekerProfile()
        {
            var skills = _profileRepository.GetSkills();
            var skillsDto = _mapper.Map<List<JobSeekerSkillDto>>(skills);
            return skillsDto;
        }

        //Get Jobseeker Profile based on  Jobseeker Id
        public List<JobSeekerProfileDTo> GetJobSeekerProfiles(Guid jobseekerId)
        {
            return _profileRepository.GetProfile(jobseekerId);

        }


        //Update Whole details of JobseekerProfile


        //public async Task<AuthUser> UpdateJobSeekerProfileAsync(AuthUserDTO userDto)
        //{
        //    if (userDto == null || userDto.JobseekerId == Guid.Empty)
        //    {
        //        throw new ArgumentException("Invalid user data.");
        //    }

        //    var existingUser = await _profileRepository.GetUserByIdAsync(userDto.JobseekerId);
        //    if (existingUser == null)
        //    {
        //        throw new KeyNotFoundException("User not found.");
        //    }

        // Update user properties
        //existingUser.UserName = userDto.UserName;
        //existingUser.FirstName = userDto.FirstName;
        //existingUser.LastName = userDto.LastName;
        //existingUser.Phone = userDto.Phone;
        //existingUser.Password = userDto.Password;

        // Handle image upload
        //    if (userDto.Image != null)
        //    {
        //        existingUser.ProfileImage = ConvertImageToByteArray(userDto.Image);
        //    }

        //    await _profileRepository.UpdateUserAsync(existingUser);

        //    return existingUser;
        //}

        //private byte[] ConvertImageToByteArray(IFormFile image)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        image.CopyTo(memoryStream);
        //        return memoryStream.ToArray();
        //    }
        //}


        //Adding profile

        public async Task<bool> AddProfile(Guid JobseekerId, ProfileDTO profileDto)
        {
            try
            {
                var jobSeekerProfile = _mapper.Map<JobSeekerProfile>(profileDto);
                await _profileRepository.AddProfile(JobseekerId,jobSeekerProfile);
                return true;
            }
            catch (Exception ex)
            {
                // Log detailed exception information
                throw new Exception($"An error occurred while saving the entity changes: {ex.Message}", ex);
            }
        }


        //Get whole jobseeker profile 
        //public List<JobSeekerProfileDTo> GetProfiles()
        //{
        //   var profiles=_profileRepository.Getprofiles();
        //    var profileDto=_mapper.Map<List<JobSeekerProfileDTo>>(profiles);
        //    return profileDto;
        //}

    }
}
