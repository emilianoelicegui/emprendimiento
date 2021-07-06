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
    public interface IProductService
    {
        Task<ServiceResponse> Get(int idProduct);
        Task<ServiceResponse> GetAllByUser(int idUser);
        Task<ServiceResponse> Save(SaveProductRequest rq);
        Task<ServiceResponse> GetAllByCompany(string name, int? idCompany, int idUser, int start, int length);
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

                sr.AddSuccess(OKResponse.GetProduct);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetProduct;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        public async Task<ServiceResponse> GetAllByUser(int idUser)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _mapper.Map<IEnumerable<ProductDto>>(await _repositoryProduct.GetAllByUser(idUser));

                sr.AddSuccess(OKResponse.GetAllProductByUser);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllProductByUser;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion GET

        #region POST

        public async Task<ServiceResponse> GetAllByCompany(string name, int? idCompany, int idUser, int start, int length)
        {
            var sr = new ServiceResponse();

            try
            {
                var totalCount = await _repositoryProduct.GetTotalByCompany(name, idUser, idCompany.Value);
                var results = _mapper.Map<IEnumerable<ProductDto>>(await _repositoryProduct.GetAllByCompany(name, idUser, idCompany, start * length, length));

                sr.Data = new
                {
                    recordsTotal = totalCount,
                    recordsFiltered = results.Count(),
                    data = results
                };

                sr.AddSuccess(OKResponse.GetAllProductByCompany);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetAllProductByCompany;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        //sirve para crear o actualizar productos
        public async Task<ServiceResponse> Save(SaveProductRequest rq)
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = await _repositoryProduct.Save(_mapper.Map<Product>(rq));

                sr.AddSuccess(OKResponse.SaveProduct);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.SaveProduct;

                sr.AddErrorException(errCode, ex);
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

                sr.AddSuccess(OKResponse.DeleteProduct);
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.DeleteProduct;

                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        #endregion PUT
    }
}
