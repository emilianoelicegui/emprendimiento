using Domain.Dto.Layer;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebsiteClient.Common;

namespace WebsiteClient.Services
{
    public interface IProductService
    {
        Task<ServiceResponse> Get(int idProduct);
        Task<ServiceResponse> GetProducts();
        Task<ServiceResponse> GetAllByCompany(string name, int? idCompany, int draw, int start, int length);
        Task<ServiceResponse> Save(SaveProductRequest rq);
        Task<ServiceResponse> Delete(int id);
    }
    public class ProductService : IProductService
    {
        private readonly ProxyHttpClient _proxyHttpClient;

        public ProductService(ProxyHttpClient proxyHttpClient)
        {
            _proxyHttpClient = proxyHttpClient;
        }

        public async Task<ServiceResponse> Get(int idProduct)
        {
            var response = await _proxyHttpClient.GetAsync($"product/{idProduct}");

            return response;

        }

        public async Task<ServiceResponse> GetProducts()
        {
            var response = await _proxyHttpClient.GetAsync("product/ListByUser");

            return response;
        }

        public async Task<ServiceResponse> GetAllByCompany(string name, int? idCompany, int draw, int start, int length)
        {
            var response = await _proxyHttpClient.GetAsync($"product/GetAllByCompany?name={name}&idCompany={idCompany}&draw={draw}&start={start}&length={length}");

            return response;
        }

        public async Task<ServiceResponse> Save(SaveProductRequest rq)
        {
            var response = await _proxyHttpClient.PostAsync($"product/save", rq);

            return response;
        }

        public async Task<ServiceResponse> Delete(int id)
        {
            var response = await _proxyHttpClient.PutAsync($"product/{id}/Delete", new object());

            return response;
        }
    }
}
