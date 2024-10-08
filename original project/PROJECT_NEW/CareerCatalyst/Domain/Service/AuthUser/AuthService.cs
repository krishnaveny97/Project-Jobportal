using Domain.Service.AuthUser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Domain.Models;

namespace Domain.Service.AuthUser
{
    public class AuthService:IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthRepository _authRepository;

        public AuthService(IHttpContextAccessor httpContextAccessor, IAuthRepository authRepository)
        {
            _httpContextAccessor=httpContextAccessor;
            _authRepository =authRepository;
        }
        //public string GetUserId()
        //{
        //    var result = string.Empty;
        //    if (_httpContextAccessor.HttpContext != null)
        //    {
        //        result = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid).Value.ToString();
        //    }
        //    return result;
        //}

        public string GetUserId()
        {
            //if (_httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Sid) != null)
            //{
            //    return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            //}
            //return string.Empty;
            var result = string.Empty;
            if (_httpContextAccessor != null &&
                _httpContextAccessor.HttpContext != null &&
                _httpContextAccessor.HttpContext.User != null)
                {
                
                if (_httpContextAccessor.HttpContext != null)
                {
                    result = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid).ToString();
                }
                
            }
            return result;
        }
        public CompanyUser GetUser(Guid userid)
        {
            return _authRepository.GetUser(userid);
        }
    }
}
