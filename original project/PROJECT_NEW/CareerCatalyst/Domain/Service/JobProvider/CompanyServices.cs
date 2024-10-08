using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.JobProvider.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
    public class CompanyServices:ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _CompanyRepo;
        public CompanyServices(IMapper mapper, ICompanyRepository CompanyRepo)
        {
            _mapper = mapper;
            _CompanyRepo = CompanyRepo;
        }

        public async Task<JobProviderCompany> AddCompany(CompanyRegistrationDto data, Guid UserId)

        {
            var jobproviderCompany = _mapper.Map<JobProviderCompany>(data);
            await _CompanyRepo.AddCompany(jobproviderCompany, UserId);


            return jobproviderCompany;

        }
        public GetCompanyDetailsDto GetCompany(Guid companyId)
        {
            var company = _CompanyRepo.GetCompany(companyId);
            var getCompanyDetailsDto = _mapper.Map<GetCompanyDetailsDto>(company);
            return getCompanyDetailsDto;
        }
        public async Task<JobProviderCompany> UpdateAsync(CompanyUpdateDtos company)
        {
            JobProviderCompany jobProviderCompany = _mapper.Map<JobProviderCompany>(company);
            var jobProviderUpdatedCompany = await _CompanyRepo.updateCompanyAsync(jobProviderCompany);
            //var ComapnyRegistrationDto = mapper.Map<CompanyRegistrationDtos>(jobProviderUpdatedCompany);
            return jobProviderUpdatedCompany;
        }

        public async Task<CompanyMemberDtos> addMember(CompanyMemberDtos companyMember, Guid companyId)
        {
            return await _CompanyRepo.AddMemberAsync(companyMember, companyId);
        }
        public async Task<PagedList<CompanyUser>> memberListing(Guid companyId, CompanyMamberListParams param)
        {
            return await _CompanyRepo.memberListing(companyId, param);
        }
        public bool memberDeleteById(Guid id)
        {
            return _CompanyRepo.memberDeleteById(id);
        }
    }
}
