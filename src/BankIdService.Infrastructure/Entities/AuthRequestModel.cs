using System;
using System.Collections.Generic;
using System.Text;

namespace BankIdService.Infrastructure.Entities
{
    public class AuthRequestModel
    {
        public string PersonalNumber { get; set; }
        public string EndUserIp { get; set; }
    }
}
