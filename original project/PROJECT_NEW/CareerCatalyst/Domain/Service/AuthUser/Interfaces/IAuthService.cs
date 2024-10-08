using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.AuthUser.Interfaces
{
    public interface IAuthService
    {
        string GetUserId();
        CompanyUser GetUser(Guid userid);
    }
}
