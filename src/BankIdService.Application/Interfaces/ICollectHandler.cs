﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BankIdService.Application.Models;
using BankIdService.Application.Responses;

namespace BankIdService.Application.Interfaces
{
    public interface ICollectHandler
    {
        Task<ActionResponse<CollectResponseModel>> SendCollectRequest(string orderRef);
    }
}
