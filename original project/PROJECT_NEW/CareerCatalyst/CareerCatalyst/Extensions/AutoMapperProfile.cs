using AutoMapper;
using CareerCatalyst.API.JobProvider.RequestObjects;
using Domain;
using Domain.Service.JobProviderSignUp.DTO;
using Domain.Models;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.Login.DTOs;
using CareerCatalyst.API.JobSeeker.RequestObjectsDtos;
using Domain.Service.Profile.DTOs;
using Domain.Service.JobSeekerSignUp.DTOs;

namespace CareerCatalyst.Extensions
{
    public class AutoMapperProfile:Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<JobProviderSignUpRequestDto, JobProviderSignUpRequest>().ReverseMap();
             CreateMap<JobProviderSignUpRequestDto, SignUpRequest>().ReverseMap();
            CreateMap<CompanyRegistrationDto, AddCompanyRequestObject>().ReverseMap();
            CreateMap<CompanyRegistrationDto, JobProviderCompany>().ReverseMap();
            CreateMap<CompanyUser, AuthUser>().ReverseMap();
            CreateMap<SignUpRequest, AuthUser>().ReverseMap();
            CreateMap<JobSeekerLoginDto,AuthUser>().ReverseMap();
            CreateMap<GetCompanyDetailsDto, JobProviderCompany>().ReverseMap();
            CreateMap<CompanyUpdateDtos,JobProviderCompany>().ReverseMap();
            CreateMap<CompanyUpdateRequest, CompanyUpdateDtos>().ReverseMap();
            CreateMap<CompanyUserRequest, CompanyMemberDtos>().ReverseMap();
            CreateMap<CompanyUser,CompanyMemberDtos>().ReverseMap();
            CreateMap<CompanyMemberDtos,AuthUser>().ReverseMap();
            CreateMap<CompanyMemberListDto,CompanyUser>().ReverseMap();
            CreateMap<InterviewSheduleObject,InterviewSheduleDto>().ReverseMap();
            CreateMap<InterviewSheduleDto, Interview>().ReverseMap();
            CreateMap<SheduledInterviewList, Interview>().ReverseMap();
            CreateMap<JobPostRequest, JobPost>().ReverseMap();

            //Jobseeker..................................................


            //Jobseeker signup
            CreateMap<JobSeekerSignuprequestDto, JobSeekerSignupRequestDto>();
            CreateMap<JobSeekerSignupRequestDto, SignUpRequest>();
            CreateMap<AuthUser, Domain.Models.JobSeeker>().ReverseMap();
            CreateMap<AuthUser, JobSeekerLoginDto>().ReverseMap();

            //Jobseeker Qualification mapping
            CreateMap<QualificationRequestDto, JobseekerQualificationDTo>();
            CreateMap<JobseekerQualificationDTo, Qualification>().ReverseMap();

            //Jobseeker workExperince
            CreateMap<WorkExperieceRequestDto, JobseekerWorkExperienceDTo>();
            CreateMap<JobseekerWorkExperienceDTo, WorkExperience>().ReverseMap();

            //Skills
            CreateMap<SkillRequestDto, JobSeekerSkillDto>();
            CreateMap<JobSeekerSkillDto, Skill>().ReverseMap();
            // CreateMap<Skill, JobSeekerSkillDto>();

            //jobseeker add 
            CreateMap<JobSeekerProfileRequestDto, ProfileDTO>();
            CreateMap<ProfileDTO, JobSeekerProfile>();


        }
    }
}
