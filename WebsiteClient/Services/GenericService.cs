using Domain.Dto.Layer;
using System.Threading.Tasks;
using WebsiteClient.Common;

namespace WebsiteClient.Services
{
    public interface IGenericService
    {
        Task<ServiceResponse> GetMenus();
    }
    public class GenericService : IGenericService
    {
        private readonly ProxyHttpClient _proxyHttpClient;

        public GenericService(ProxyHttpClient proxyHttpClient)
        {
            _proxyHttpClient = proxyHttpClient;
        }

        public async Task<ServiceResponse> GetMenus()
        {
            var response = await _proxyHttpClient.GetAsync("generic/getMenus");

            return response;
        }
    }
}
