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
    public interface IInterviewService
    {
        Interview sheduleinterview(InterviewSheduleDto interview, CompanyUser userId);
        List<Interview> sheduledInterviewList(Guid companyid);
        bool removeInterview(Guid id);
    }
}
