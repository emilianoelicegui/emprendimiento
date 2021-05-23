using AutoMapper;
using Domain.Dto.Layer;
using Domain.Layer;
using Emprendimiento.API.Repositories;
using Shared.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Services
{
    public interface ISpendingService
    {
        Task<ServiceResponse> GetAllTypes();
        Task<ServiceResponse> GetAllByUser(int idUser);
        Task<ServiceResponse> GetAllByCompany(int? idCompany, int start, int length);
        Task<ServiceResponse> Save(SaveSpendingRequest rq);
    }
    
    public class SpendingService : ISpendingService
    {

        private readonly IMapper _mapper;
        private readonly IRepositorySpending _repositorySpending;

        public SpendingService(IRepositorySpending repositorySpending, IMapper mapper)
        {
            _repositorySpending = repositorySpending;
            _mapper = mapper;
        }

        #region GET

        public async Task<ServiceResponse> GetAllTypes()
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositorySpending.GetAllTypes();
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllTypesSpending;
                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetAllByUser(int idUser)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositorySpending.GetAllByUser(idUser);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllSpendingsByUser;
                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetAllByCompany(int? idCompany, int start, int length)
        {
            var sr = new ServiceResponse();

            try
            {
                var results = _mapper.Map<IEnumerable<SpendingListDto>>(await _repositorySpending.GetAllByCompany(idCompany, start, length));

                sr.Data = new
                {
                    recordsTotal = results.Count(),
                    recordsFiltered = results.Count(),
                    data = results
                };

                sr.AddSuccess(OKResponse.GetAllSpendingsByCompany);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllSpendingsByCompany;
                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion GET

        #region POST

        public async Task<ServiceResponse> Save(SaveSpendingRequest rq)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositorySpending.Save(_mapper.Map<Spending>(rq));

                sr.AddSuccess(OKResponse.SaveSpending);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.SaveSpending;
                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion POST
    }
}
