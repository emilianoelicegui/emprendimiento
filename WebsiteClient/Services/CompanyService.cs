using Domain.Dto.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteClient.Common;

namespace WebsiteClient.Services
{
    public interface ICompanyService
    {
        Task<ServiceResponse> GetAllByUser();
    }
    public class CompanyService : ICompanyService
    {
        private readonly ProxyHttpClient _proxyHttpClient;

        public CompanyService(ProxyHttpClient proxyHttpClient)
        {
            _proxyHttpClient = proxyHttpClient;
        }

        public async Task<ServiceResponse> GetAllByUser()
        {
            var response = await _proxyHttpClient.GetAsync($"company/ListByUser");

            return response;

        }

    }
}
