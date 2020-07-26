using Domain.Dto.Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteClient.Common
{
    public class ProxyHttpClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProxyHttpClient(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public const string EmprendimientoApi = "EmprendimientoApi";

        public HttpClient Get(string requestUrl)
        {
            var client = new HttpClient();
            var url = _configuration.GetValue<string>($"APIs:{EmprendimientoApi}") + requestUrl;

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (_httpContextAccessor.HttpContext.User != null && _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims;
                var access_token = claims.Single(x => x.Type.Equals("Token")).Value;

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");
            }

            return client;
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public async Task<LoginResponseDto> PostLoginAsync<T>(string requestUrl, T content)
        {
            var _httpClient = Get(requestUrl);

            var response = await _httpClient.PostAsync(_httpClient.BaseAddress, CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponseDto>(data);
        }

        public async Task<ServiceResponse> PostAsync<T>(string requestUrl, T content)
        {
            var _httpClient = Get(requestUrl);

            var response = await _httpClient.PostAsync(_httpClient.BaseAddress, CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ServiceResponse>(data);
        }

        public async Task<ServiceResponse> PutAsync<T>(string requestUrl, T content)
        {
            var _httpClient = Get(requestUrl);

            var response = await _httpClient.PutAsync(_httpClient.BaseAddress, CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ServiceResponse>(data);
        }

        public async Task<ServiceResponse> GetAsync(string requestUrl)
        {
            var _httpClient = Get(requestUrl);

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ServiceResponse>(data);
        }

    }
}
