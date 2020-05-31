using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankIdService.Api.ApiModels
{
    public class AuthRequestDto
    {
        public string PersonalNumber { get; set; }
        public string EndUserIp { get; set; }
    }
}
