using System.Threading.Tasks;
using BankIdService.Application.Models;
using BankIdService.Application.Responses;

namespace BankIdService.Application.Interfaces
{
    public interface IAuthHandler
    {
        Task<ActionResponse<AuthModel>> SendAuthRequest(string personalNumber = null);
    }
}
