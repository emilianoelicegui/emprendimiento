using AutoMapper;
using Domain.Dto.Layer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Shared.Layer;
using Newtonsoft.Json;
using Emprendimiento.API.Repositories;
using Domain.Layer;

namespace Emprendimiento.API.Services.Recurring
{
    public interface IRecurringService
    {
        Task<bool> UpdateDolarBlueValue();
        Task<ServiceResponse> GetDolarBlue();
        Task<IEnumerable<DolarResponse>> GetListDolarBlue();
    }

    public class RecurringService : IRecurringService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        private readonly IRepositoryRecurring _repositoryRecurring;

        public RecurringService(IMapper mapper, IConfiguration configuration, IRepositoryRecurring repositoryRecurring)
        {
            _mapper = mapper;
            _configuration = configuration;

            _repositoryRecurring = repositoryRecurring;
        }

        public async Task<bool> UpdateDolarBlueValue()
        {
            try
            {
                var dolarResponses = await GetListDolarBlue();

                await _repositoryRecurring.UpdateDolarBlueValue(_mapper.Map<DolarBlueValue>(dolarResponses.First()));
            }
            catch (Exception ex)
            {
                //var errCode = ErrorCodes.GetServiceDolarBlue;
                //sr.AddErrorException(errCode, ex);
                return false;
            }

            return true;
        }

        public async Task<ServiceResponse> GetDolarBlue()
        {
            var sr = new ServiceResponse();

            try
            {
                using (var client = new HttpClient())
                {
                    sr.Data = GetListDolarBlue().Result.First();
                }
            }
            catch (Exception ex)
            {
                var errCode = ErrorCodes.GetServiceDolarBlue;
                sr.AddErrorException(errCode, ex);
            }

            return sr;
        }

        public async Task<IEnumerable<DolarResponse>> GetListDolarBlue()
        {
            using (var client = new HttpClient())
            {
                var token = _configuration.GetValue<string>("Services:TokenServiceGetDolarBlue");
                var url = _configuration.GetValue<string>("Services:UrlServiceGetDolarBlue");

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url)
                };

                var response = await client.SendAsync(request);
                
                return response.Content.ReadAsAsync<List<DolarResponse>>().Result.OrderByDescending(x => x.d);
            }
        }
    }
}
