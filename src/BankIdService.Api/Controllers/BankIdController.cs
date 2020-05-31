using System.Threading.Tasks;
using AutoMapper;
using BankIdService.Api.ApiModels;
using BankIdService.Application.Interfaces;
using BankIdService.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankIdService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankIdController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthHandler _authHandler;
        private readonly ICollectHandler _collectHandler;

        public BankIdController(IMapper mapper, IAuthHandler authHandler, ICollectHandler collectHandler)
        {
            _mapper = mapper;
            _authHandler = authHandler;
            _collectHandler = collectHandler;
        }

        /// <summary>
        /// Auth Request to bankId
        /// </summary>
        /// <param name="authRequestDto"></param>
        /// <returns>A orderref and autostarttoken</returns>
        /// <response code="400">Auth has already been requested</response>
        /// <response code="200">Sucessfully started auth sequence</response>
        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] AuthRequestDto authRequestDto)
        {
            if (authRequestDto == null)
                return BadRequest();

            var result = await _authHandler.SendAuthRequest(_mapper.Map<AuthRequestModel>(authRequestDto));

            return Ok(_mapper.Map<AuthResponseDto>(result.Payload));
        }

        [HttpGet]
        public async Task<IActionResult> Collect(string orderRef)
        {
            if (string.IsNullOrEmpty(orderRef))
                return BadRequest("orderref cannot be empty");

            var result = await _collectHandler.SendCollectRequest(orderRef);

            return Ok(_mapper.Map<CollectResponseDto>(result.Payload));

        }
    }
}
