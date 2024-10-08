using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.JobProvider.Interface;

namespace Domain.Service.JobProvider
{
    public class InterviewService:IInterviewService
    {
        public IInterviewRepository _interviewRepository { get; set; }
        public InterviewService(IInterviewRepository interviewRepository)
        {
            _interviewRepository= interviewRepository;
        }
        public Interview sheduleinterview(InterviewSheduleDto interview, CompanyUser userId)
        {
            return _interviewRepository.shduleInterview(interview, userId);
        }
        public  List<Interview> sheduledInterviewList(Guid companyid)
        {
            return _interviewRepository.sheduledInterviewList(companyid);
        }
        public bool removeInterview(Guid id)
        {
            return _interviewRepository.removeInterview(id);
        }

    }
}
