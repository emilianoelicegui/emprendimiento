using Domain.Dto.Layer;
using Microsoft.AspNetCore.Mvc;
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
        Task<ServiceResponse> GetAllByCompany(string name, int? idCompany, int draw, int start, int length);
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

        public async Task<ServiceResponse> GetAllByCompany(string name, int? idCompany, int draw, int start, int length)
        {
            var response = await _proxyHttpClient.GetAsync($"product/GetAllByCompany?name={name}&idCompany{idCompany}?draw={draw}&start={start}&length={length}");

            return response;
        }
    }
}
