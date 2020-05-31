using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using BankIdService.Application.Configurations;
using Microsoft.Extensions.Options;

namespace BankIdService.Api.HttpClientExtensions
{
    public class HttpCertificateHandler : HttpClientHandler
    {
        private readonly BankIdSettings _settings;
        public HttpCertificateHandler(IOptions<BankIdSettings> settings)
        {
            _settings = settings.Value;

            var certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            certStore.Open(OpenFlags.ReadOnly);
            var certCollection = certStore.Certificates.Find(
                X509FindType.FindByThumbprint,
                _settings.Certificate,
                false);

            if (certCollection.Count == 0)
                throw new ArgumentNullException($"There is no certificate with thumbprint {_settings.Certificate}");

            X509Certificate2 certificate = certCollection[0];
            ClientCertificateOptions = ClientCertificateOption.Manual;
            SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
            ClientCertificates.Add(certificate);

            ServerCertificateCustomValidationCallback = DangerousAcceptAnyServerCertificateValidator;

        }
    }
}
