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
    public interface ISaleService
    {
        Task<ServiceResponse> Get(int idSale);
        Task<ServiceResponse> GetItems(int idSale);
        Task<ServiceResponse> GetAllByUser(int idUser);
        Task<ServiceResponse> GetAllByCompany(int? idCompany, int idUser, int start, int length);

        Task<ServiceResponse> Save(SaveSaleRequest rq);

        Task<ServiceResponse> Delete(int idSale);
    }
    public class SaleService : ISaleService
    {
        private readonly IMapper _mapper;
        private readonly IRepositorySale _repositorySale;

        public SaleService(IMapper mapper, IRepositorySale repositorySale)
        {
            _mapper = mapper;
            _repositorySale = repositorySale;
        }

        #region GET

        public async Task<ServiceResponse> Get(int idSale)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<SaleDto>(await _repositorySale.Get(idSale));
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetSale;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetItems(int idSale)
        {
            var sr = new ServiceResponse();

            try
            {
                var results = _mapper.Map<IEnumerable<ItemSaleListDto>>(await _repositorySale.GetItems(idSale));

                sr.Data = new
                {
                    recordsTotal = results.Count(),
                    recordsFiltered = results.Count(),
                    data = results
                };
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetSale;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetAllByUser(int idUser)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<SaleDto>>(await _repositorySale.GetAllByUser(idUser));
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllSalesByUser;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion GET

        #region POST

        public async Task<ServiceResponse> GetAllByCompany(int? idCompany, int idUser, int start, int length)
        {
            var sr = new ServiceResponse();

            try
            {
                var totalCount = await _repositorySale.GetTotalByCompany(idUser, idCompany);
                var results = _mapper.Map<IEnumerable<SaleListDto>>(await _repositorySale.GetAllByCompany(idUser, idCompany, start * length, length));

                sr.Data = new
                {
                    recordsTotal = totalCount,
                    recordsFiltered = results.Count(),
                    data = results
                };
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllSalesByCompany;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        //sirve para crear o actualizar productos
        public async Task<ServiceResponse> Save(SaveSaleRequest rq)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositorySale.Save(_mapper.Map<Sale>(rq));

                sr.AddSuccess(OKResponse.SaveSale);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.SaveSale;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion POST

        #region PUT

        public async Task<ServiceResponse> Delete(int idSale)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositorySale.Delete(idSale);

                sr.AddSuccess(OKResponse.DeleteSale);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.DeleteSale;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion PUT
    }
}
