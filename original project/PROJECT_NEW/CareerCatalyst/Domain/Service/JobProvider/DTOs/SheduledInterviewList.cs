using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.DTOs
{
    public class SheduledInterviewList
    {
        public Guid Id;
        public Guid ApplicationId {  get; set; }
        public string CompanyLegalName {  get; set; }
        public string IntervieweeNavigationUserName {  get; set; }
        public string JobJobTitle {  get; set; }
        public string SheduledByNavigationFirstName{  get; set; }
        //public DateTime? Date { get; set; }

    }
}
