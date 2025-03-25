﻿using System.Threading.Tasks;
using BankIdService.Application.Interfaces;
using BankIdService.Application.Models;
using BankIdService.Application.Responses;

namespace BankIdService.Application.Handlers
{
    public class AuthHandler : IAuthHandler
    {
        private readonly IBankIdServiceHandler _bankIdService;
        public AuthHandler(IBankIdServiceHandler bankIdService)
        {
            _bankIdService = bankIdService;
        }

        public async Task<ActionResponse<AuthResponseModel>> SendAuthRequest(AuthRequestModel authRequestModel)
        {
            var result = await _bankIdService.SendAuthRequest(authRequestModel);

            return new ActionResponse<AuthResponseModel>(true) { Payload = result };
        }
    }
}
