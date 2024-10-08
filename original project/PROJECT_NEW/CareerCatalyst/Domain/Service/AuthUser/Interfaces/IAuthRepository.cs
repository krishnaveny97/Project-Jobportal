using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.AuthUser.Interfaces
{
    public interface IAuthRepository
    {
        Task<Domain.Models.AuthUser> AddAuthUser(Domain.Models.AuthUser authUser);
      //  string? CreateToken(AuthUser user);
        string? CreateToken(Models.AuthUser user);
        CompanyUser GetUser(Guid userid);
    }
}
