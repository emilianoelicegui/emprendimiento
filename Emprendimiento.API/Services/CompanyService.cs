using AutoMapper;
using Domain.Dto.Layer;
using Emprendimiento.API.Repositories;
using Shared.Layer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprendimiento.API.Services
{
    public interface ICompanyService
    {
        Task<ServiceResponse> Get(int idCompany);
        Task<ServiceResponse> GetAllByUser(int idUser);
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

        #region GET

        public async Task<ServiceResponse> Get(int idCompany)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<CompanyDto>(await _repositoryCompany.Get(idCompany));
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetCompany;
                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }


        public async Task<ServiceResponse> GetAllByUser(int idUser)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<CompanyLoginDto>>(await _repositoryCompany.GetAllByUser(idUser));
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllCompanysByUser;
                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion GET
    }
}
