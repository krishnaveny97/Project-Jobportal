using Domain;
using Domain.Models;
using Domain.Service.Authuser;
using Domain.Service.Authuser.Interfaces;
using Domain.Service.AuthUser;
using Domain.Service.AuthUser.Interfaces;
using Domain.Service.JobProvider;
using Domain.Service.JobProvider.Interface;
using Domain.Service.JobProviderSignUp;
using Domain.Service.JobProviderSignUp.Interface;
using Domain.Service.Login;
using Domain.Service.Login.Interfaces;
using Domain.Service.Profile;
using Domain.Service.Profile.Interface;
using Domain.Service.JobSeekerSignUp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Domain.Service.JobSeekerSignUp;



namespace CareerCatalyst.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection service,IConfiguration configure) 
        {
            service.AddScoped<Domain.Service.JobProviderSignUp.Interface.ISignUpRequestRepository, SignUpRequestRepository>();
            service.AddScoped<Domain.Service.JobProviderSignUp.Interface.ISignUpRequestService, SignUpRequestService>();
            service.AddScoped<ILoginRequestService, LoginRequestService>();
            service.AddScoped<ILoginRequestRepository, LoginRequestRepository>();
            service.AddScoped<IAuthRepository,AuthRepository>();
            service.AddScoped<IAuthService,AuthService>();
            service.AddScoped<ICompanyService, CompanyServices>();
            service.AddScoped<ICompanyRepository, CompanyRepository>();
            service.AddScoped<IMailService,EmailService>();
            service.AddScoped<IInterviewService,InterviewService>();
            service.AddScoped<IInterviewRepository, InterviewRepository>();
            service.AddDbContext<NewDbContext>(options => options.UseSqlServer(configure.GetConnectionString("DefaultConnection")));
            service.AddScoped<NewDbContext>();
            service.AddHttpContextAccessor();
            // service.AddAutoMapper(typeof(AutoMapperProfile).Assembly);



            //Jobseeker...........
            //signup repository services
            service.AddScoped<IJobseekerSignUpRequestRepository, JobseekerSignUpRequestRepository>();
            service.AddScoped<IJobseekerSignUpRequestService, JobseekerSignUpRequestService>();

            //email service
            service.AddScoped<IMailService, EmailService>();

            //Authuser repository
            service.AddScoped<IAuthUserRepository, AuthUserRepository>();

            //Login repository services
            service.AddScoped<ILoginRequestRepository, LoginRequestRepository>();
            service.AddScoped<ILoginRequestService, LoginRequestService>();

            //Profile repository services
            service.AddScoped<IJobSeekerProfileRepository, ProfileRepository>();
            service.AddScoped<IJobSeekerProfileService, ProfileService>();

            return service;
        }
    }
}
