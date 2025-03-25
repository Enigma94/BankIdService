using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace BankIdService.Api.HttpClientExtensions
{
    public class HttpBankIdRequestHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "" };

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
