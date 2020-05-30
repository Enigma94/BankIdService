using System.Threading.Tasks;
using AutoMapper;
using BankIdService.Api.ApiModels;
using BankIdService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankIdService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankIdController : ControllerBase
    {
        private readonly ILogger<BankIdController> _logger;
        private readonly IAuthHandler _authHandler;
        private readonly IMapper _mapper;

        public BankIdController(ILogger<BankIdController> logger, IAuthHandler authHandler, IMapper mapper)
        {
            _logger = logger;
            _authHandler = authHandler;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Auth(string personalNumber)
        {
            if (personalNumber == null)
                return BadRequest();

            var result = await _authHandler.SendAuthRequest(personalNumber);

            return Ok(_mapper.Map<AuthModelDto>(result.Payload));
        }
    }
}
