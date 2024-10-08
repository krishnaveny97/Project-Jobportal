using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Helpers;

namespace Domain
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
