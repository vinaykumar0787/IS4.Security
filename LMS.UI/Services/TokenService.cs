using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace LMS.UI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<IdentityServerSettings> identityServerSettings;
        private readonly DiscoveryDocumentResponse discoveryDocument;
        private readonly HttpClient httpClient;

        public TokenService(IOptions<IdentityServerSettings> identityServerSettings)
        {
            this.identityServerSettings = identityServerSettings;
            httpClient = new HttpClient();
            discoveryDocument = httpClient.GetDiscoveryDocumentAsync(this.identityServerSettings.Value.DiscoveryUrl).Result;

            if(discoveryDocument.IsError)
            {
                throw new Exception("unable to get discovery document", discoveryDocument.Exception);
            }
        }
        public async Task<TokenResponse> GetToken(string scope)
        {
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = identityServerSettings.Value.ClientName,
                ClientSecret = identityServerSettings.Value.ClientPassword,
                Scope = scope
            });
            if(tokenResponse.IsError)
            {
                throw new Exception("unable to get token", tokenResponse.Exception);
            }
            return tokenResponse;
        }
    }
}
