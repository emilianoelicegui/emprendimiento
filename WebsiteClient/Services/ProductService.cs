using Domain.Dto.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteClient.Common;

namespace WebsiteClient.Services
{
    public interface IProductService
    {
        Task<ServiceResponse> GetProducts();
    }
    public class ProductService : IProductService
    {
        private readonly ProxyHttpClient _proxyHttpClient;

        public ProductService(ProxyHttpClient proxyHttpClient)
        {
            _proxyHttpClient = proxyHttpClient;
        }

        public async Task<ServiceResponse> GetProducts()
        {
            var response = await _proxyHttpClient.GetAsync("product/ListByUser");

            return response;
        }
    }
}
