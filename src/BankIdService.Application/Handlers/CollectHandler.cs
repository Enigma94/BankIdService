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
            var result =  await _bankIdService.SendCollectRequest(orderRef);

            result.UserMessage = GetUserMessage(result?.HintCode, result?.Status);

            return new ActionResponse<CollectResponseModel>(true) { Payload = result};
        }

        private string GetUserMessage(string hintCode, string status)
        {
            if (status == "pending")
            {
                switch (hintCode)
                {
                    case "noClient":
                        return BankIdMessages.RFA1;
                    case "userSign":
                        return BankIdMessages.RFA9;
                    case "outstandingTransaction":
                        return BankIdMessages.RFA13;
                    case "started":
                        return BankIdMessages.RFA14_A;
                    default:
                        break;
                }
            }

            if (status == "failed")
            {
                switch (hintCode)
                {
                    case "expiredTransaction":
                        return BankIdMessages.RFA8;
                    case "certificateErr":
                        return BankIdMessages.RFA16;
                    default:
                        break;
                }
            }

            return null;
        }
    }
}
