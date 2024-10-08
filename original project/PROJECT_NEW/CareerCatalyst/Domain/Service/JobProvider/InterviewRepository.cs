using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Enum;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.JobProvider.Interface;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service.JobProvider
{
    public class InterviewRepository:IInterviewRepository
    {
        NewDbContext _context;
        public IMapper mapper { get; set; }

        public InterviewRepository(NewDbContext  context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        public Interview shduleInterview(InterviewSheduleDto interview, CompanyUser user)

        {
            try
            {
                JobApplication application = _context.JobApplications.Where(a => a.Id == interview.ApplicationId).Include(e => e.JobPost).FirstOrDefault();
                var interviewtoshedule = mapper.Map<Interview>(interview);
                interviewtoshedule.JobId = application.JobPostId;
                interviewtoshedule.ApplicationId = application.Id;
                interviewtoshedule.Status =(Int32) JobStatusInterview.SCHEDULED;
                interviewtoshedule.SheduledBy = user.Id;
                interviewtoshedule.Interviewee = application.Applicant;
                interviewtoshedule.CompanyId = (Guid)user.Company;


                _context.Interviews.AddAsync(interviewtoshedule);
                _context.SaveChanges();
                return interviewtoshedule;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public  List<Interview> sheduledInterviewList(Guid companyid)
        {
            //var query = _context.Interviews.Where(e=>e.CompanyId== companyid).ToList();
            var query = _context.Interviews
               .OrderByDescending(c => c.Date).Where(e => e.CompanyId == companyid).Include(e => e.Job).Include(e => e.Application).Include(e => e.Company).Include(e => e.SheduledByNavigation).Include(e=>e.IntervieweeNavigation)
               .AsQueryable().ToList();
            return query;
                   


        }
        public bool removeInterview(Guid id)
        {
            Interview interview = _context.Interviews.FirstOrDefault(e => e.Id == id);
            if (interview != null)
            {
                _context.Interviews.Remove(interview);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
