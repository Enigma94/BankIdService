﻿using System.Threading.Tasks;
using BankIdService.Application.Models;
using BankIdService.Application.Responses;

namespace BankIdService.Application.Interfaces
{
    public interface IBankIdServiceHandler
    {
        Task<AuthResponseModel> SendAuthRequest(AuthRequestModel authRequestModel);
        Task<CollectResponseModel> SendCollectRequest(string orderRef);
    }
}
