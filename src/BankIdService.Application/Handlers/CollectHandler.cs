using System.Threading.Tasks;
using BankIdService.Application.Interfaces;
using BankIdService.Application.Models;
using BankIdService.Application.Responses;

namespace BankIdService.Application.Handlers
{
    public class CollectHandler : ICollectHandler
    {
        private readonly IBankIdServiceHandler _bankIdService;
        public CollectHandler(IBankIdServiceHandler bankIdService)
        {
            _bankIdService = bankIdService;
        }
        public async Task<ActionResponse<CollectResponseModel>> SendCollectRequest(string orderRef)
        {
            return await _bankIdService.SendCollectRequest(orderRef);
        }
    }
}
