using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BankIdService.Application.Interfaces;
using BankIdService.Application.Models;
using BankIdService.Application.Responses;

namespace BankIdService.Infrastructure.Services
{
    public class BankIdService : IBankIdService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public BankIdService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;

        }

        public async Task<ActionResponse<AuthModel>> SendAuthRequest(string personalNumber)
        {
            var infraAuth = new Entities.AuthModel();

            var mapped = _mapper.Map<AuthModel>(infraAuth);

            return new ActionResponse<AuthModel>(true) { Payload = mapped };
        }
    }
}
