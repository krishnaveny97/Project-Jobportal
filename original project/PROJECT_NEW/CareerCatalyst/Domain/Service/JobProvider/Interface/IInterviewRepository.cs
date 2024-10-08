using Domain.Helpers;
using Domain.Models;
using Domain.Service.JobProvider.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.Interface
{
    public interface IInterviewRepository
    {
        Interview shduleInterview(InterviewSheduleDto interview, CompanyUser user);
       List<Interview> sheduledInterviewList(Guid companyid);
        bool removeInterview(Guid id);
    }
}
