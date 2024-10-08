using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.DTOs
{
    public class ScheduleInterviewDto
    {
        public Guid Id { get; set; }
        public string JobJobTitle { get; set; }
        public string JobseekerUsername { get; set; }

        public Guid ApplicationId { get; set; }

        public DateTime? Date { get; set; }


        public JobStatusInterview Status { get; set; }
        public string CompanyUserUserName { get; set; }


    }
}
