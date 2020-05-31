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
        private readonly IAuthHandler _authHandler;
        private readonly IMapper _mapper;

        public BankIdController(IAuthHandler authHandler, IMapper mapper)
        {
            _authHandler = authHandler;
            _mapper = mapper;
        }

        /// <summary>
        /// Auth Request to bankId
        /// </summary>
        /// <param name="authRequestDto"></param>
        /// <returns>A orderref and autostarttoken</returns>
        /// <response code="400">Auth has already been requested</response>
        /// <response code="200">Sucessfully started auth sequence</response>
        [HttpPost]
        public async Task<IActionResult> Auth([FromBody]AuthRequestDto authRequestDto)
        {
            if (authRequestDto == null)
                return BadRequest();

            var result = await _authHandler.SendAuthRequest(_mapper.Map<AuthRequestModel>(authRequestDto));

            return Ok(_mapper.Map<AuthResponseDto>(result.Payload));
        }
    }
}
