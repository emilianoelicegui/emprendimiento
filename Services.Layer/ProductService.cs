using AutoMapper;
using Domain.Dto.Layer;
using Domain.Layer;
using Repositories.Layer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Layer
{
    public interface IProductService
    {
        Task<ServiceResponse> Get(int idProduct);
        Task<ServiceResponse> GetAllByCompany(int idCompany);
        Task<ServiceResponse> GetAllByUser(int idUser);
        Task<ServiceResponse> Save(SaveProductRequest rq);
        Task<ServiceResponse> Delete(int idProduct);
    }
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryProduct _repositoryProduct;

        public ProductService(IRepositoryProduct repositoryProduct, IMapper mapper)
        {
            _repositoryProduct = repositoryProduct;
            _mapper = mapper;
        }

        #region GET

        public async Task<ServiceResponse> Get(int idProduct)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<ProductDto>(await _repositoryProduct.Get(idProduct));
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetAllByCompany(int idCompany)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<ProductDto>>(await _repositoryProduct.GetAllByCompany(idCompany));
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
                sr.Data = _mapper.Map<IEnumerable<ProductDto>>(await _repositoryProduct.GetAllByUser(idUser));
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
        public async Task<ServiceResponse> Save(SaveProductRequest rq)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositoryProduct.Save(_mapper.Map<Product>(rq));
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }

        #endregion POST

        #region PUT

        public async Task<ServiceResponse> Delete(int idProduct)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositoryProduct.Delete(idProduct);
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
