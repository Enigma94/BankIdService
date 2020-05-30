using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankIdService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankIdController : ControllerBase
    {
        private readonly ILogger<BankIdController> _logger;

        public BankIdController(ILogger<BankIdController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Auth(string personalNumber)
        {
            return Ok();
        }
    }
}
