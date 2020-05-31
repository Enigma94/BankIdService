﻿using System.Threading.Tasks;
using BankIdService.Application.Models;
using BankIdService.Application.Responses;

namespace BankIdService.Application.Interfaces
{
    public interface IBankIdServiceHandler
    {
        Task<ActionResponse<AuthResponseModel>> SendAuthRequest(AuthRequestModel authRequestModel);
        Task<ActionResponse<CollectResponseModel>> SendCollectRequest(string orderRef);
    }
}
