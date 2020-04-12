using AutoMapper;
using Domain.Dto.Layer;
using Repositories.Layer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Layer
{
    public interface ICompanyService
    {
        Task<ServiceResponse> Get(int idCompany);
        Task<ServiceResponse> GetAll(int idUser);
    }
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryCompany _repositoryCompany;

        public CompanyService(IRepositoryCompany repositoryCompany, IMapper mapper)
        {
            _repositoryCompany = repositoryCompany;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Get(int idCompany)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<CompanyDto>(await _repositoryCompany.Get(idCompany));
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }


        public async Task<ServiceResponse> GetAll(int idUser)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<CompanyLoginDto>>(await _repositoryCompany.GetAll(idUser));
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }
    }
}
