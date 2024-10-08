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
    public interface ICompanyService
    {
        Task<JobProviderCompany> AddCompany(CompanyRegistrationDto data, Guid UserId);
        GetCompanyDetailsDto GetCompany(Guid companyId);
        Task<JobProviderCompany> UpdateAsync(CompanyUpdateDtos company);
        Task<CompanyMemberDtos> addMember(CompanyMemberDtos companyMember, Guid companyId);
        Task<PagedList<CompanyUser>> memberListing(Guid companyId, CompanyMamberListParams param);
        bool memberDeleteById(Guid id);
    }
}
