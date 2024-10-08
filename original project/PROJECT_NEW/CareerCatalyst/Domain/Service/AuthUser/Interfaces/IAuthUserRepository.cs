using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Authuser.Interfaces
{
    public interface IAuthUserRepository
    {
         Task<Domain.Models.AuthUser> AddAuthUser(Domain.Models.AuthUser authUser);
         string? CreateToken(Domain.Models.AuthUser user);
    }
}
