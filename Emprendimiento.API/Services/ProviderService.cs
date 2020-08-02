using AutoMapper;
using Domain.Dto.Layer;
using Domain.Layer;
using Emprendimiento.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprendimiento.API.Services
{
    public interface IProviderService
    {
        Task<ServiceResponse> Get(int idProvider);
        Task<ServiceResponse> GetAllByUser(int idUser);
        Task<ServiceResponse> Save(SaveProviderRequest rq);
        Task<ServiceResponse> Delete(int idProvider);
    }
    public class ProviderService : IProviderService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryProvider _repositoryProvider;

        public ProviderService(IRepositoryProvider repositoryProvider, IMapper mapper)
        {
            _repositoryProvider = repositoryProvider;
            _mapper = mapper;
        }

        #region GET

        public async Task<ServiceResponse> Get(int idProvider)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<ProductDto>(await _repositoryProvider.Get(idProvider));
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetAllByUser(int idUser)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<ProviderDto>>(await _repositoryProvider.GetAllByUser(idUser));
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }

        #endregion GET

        #region POST

        //sirve para crear o actualizar productos
        public async Task<ServiceResponse> Save(SaveProviderRequest rq)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositoryProvider.Save(_mapper.Map<Provider>(rq));
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }

        #endregion POST

        #region PUT

        public async Task<ServiceResponse> Delete(int idProvider)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositoryProvider.Delete(idProvider);
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }

        #endregion PUT
    }
}
