using System;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<ActionResponse<AuthResponseModel>> SendAuthRequest(AuthRequestModel authRequestModel)
        {
            try
            {
                var request = CreateRequest(authRequestModel, _settings.AuthUrl);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "" };
                var response = await _httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                if (response.IsSuccessStatusCode)
                {
                    var entityAuthModel = JsonSerializer.Deserialize<Entities.AuthResponseModel>(content, options);
                    var mapped = _mapper.Map<AuthResponseModel>(entityAuthModel);

                    return new ActionResponse<AuthResponseModel>(true) { Payload = mapped };
                }

                return new ActionResponse<AuthResponseModel>(false);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                throw;
            }
        }
    }
}
