using Domain.Dto.Layer;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebsiteClient.Common;

namespace WebsiteClient.Services
{
    public interface IAccountService
    {
        Task<LoginResponseDto> Authenticate(LoginRequestDto rq);
    }
    public class AccountService : IAccountService
    {
        private readonly ProxyHttpClient _proxyHttpClient;

        public AccountService(ProxyHttpClient proxyHttpClient)
        {
            _proxyHttpClient = proxyHttpClient;
        }

        public async Task<LoginResponseDto> Authenticate(LoginRequestDto model)
        {
            var response = await _proxyHttpClient.PostLoginAsync("auth/login", model);

            return response;
        }
    }
}
