using System.Threading.Tasks;
using BankIdService.Application.Interfaces;
using BankIdService.Application.Models;
using BankIdService.Application.Responses;

namespace BankIdService.Application.Handlers
{
    public class AuthHandler : IAuthHandler
    {
        private readonly IBankIdService _bankIdService;
        public AuthHandler(IBankIdService bankIdService)
        {
            _bankIdService = bankIdService;
        }

        public async Task<ActionResponse<AuthModel>> SendAuthRequest(string personalNumber = null)
        {
            return await _bankIdService.SendAuthRequest("123");
        }

    }
}
