using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using BankIdService.Application.Configurations;
using BankIdService.Application.Interfaces;
using BankIdService.Application.Models;
using BankIdService.Application.Responses;
using Microsoft.Extensions.Options;
using Serilog;

namespace BankIdService.Infrastructure.Services
{
    public class BankIdServiceHandler : IBankIdServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly BankIdSettings _settings;

        public BankIdServiceHandler(IMapper mapper, HttpClient httpClient, IOptions<BankIdSettings> settings)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _settings = settings.Value;

        }

        public async Task<ActionResponse<AuthResponseModel>> SendAuthRequest(AuthRequestModel authRequestModel)
        {
            try
            {
                var response = await SendAsync<AuthRequestModel, AuthResponseModel>(authRequestModel, _settings.AuthUrl);

                if (response != null)
                    return new ActionResponse<AuthResponseModel>(true) { Payload = response };

                return new ActionResponse<AuthResponseModel>(false);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        public async Task<ActionResponse<CollectResponseModel>> SendCollectRequest(string orderRef)
        {
            try
            {
                var response = await SendAsync<object, CollectResponseModel>(new { orderRef }, _settings.CollectUrl);

                if (response != null)
                    return new ActionResponse<CollectResponseModel>(true) { Payload = response };

                return new ActionResponse<CollectResponseModel>(false);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }

        private async Task<U> SendAsync<T, U>(T requestModel, string url)
        {
            var request = CreateRequest(requestModel, url);
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            if (response.IsSuccessStatusCode)
            {
                var derserializedContent = JsonSerializer.Deserialize<U>(content, options);
                return _mapper.Map<U>(derserializedContent);
            }

            return default;
        }

        private HttpRequestMessage CreateRequest<T>(T content, string endpoint)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = new StringContent(JsonSerializer.Serialize(content, options))
            };
        }
    }
}
