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
    public interface ICompanyRepository
    {
        Task AddCompany(JobProviderCompany data, Guid UserId);
        JobProviderCompany GetCompany(Guid companyId);
        Task<JobProviderCompany> updateCompanyAsync(JobProviderCompany company);
        Task<CompanyMemberDtos> AddMemberAsync(CompanyMemberDtos companyMember, Guid companyId);
        Task<PagedList<CompanyUser>> memberListing(Guid companyId, CompanyMamberListParams param);
        bool memberDeleteById(Guid id);
    }
}
