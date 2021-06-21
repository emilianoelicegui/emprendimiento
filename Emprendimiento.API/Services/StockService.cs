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
    public interface IStockService
    {
        Task<ServiceResponse> Save(SaveStockRequest rq);
    }

    public class StockService : IStockService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryStock _repositoryStock;

        public StockService(IRepositoryStock repositoryStock, IMapper mapper)
        {
            _repositoryStock = repositoryStock;
            _mapper = mapper;
        }

        #region 

        public async Task<ServiceResponse> Save(SaveStockRequest rq)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositoryStock.Save(_mapper.Map<Stock>(rq));

                sr.AddSuccess(OKResponse.SaveProduct);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.SaveProduct;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion

    }
}
