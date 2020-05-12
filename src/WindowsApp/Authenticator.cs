using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace App
{
    internal class Authenticator
    {
        // Will cache DNS while the app is running
        private static HttpClient HttpClient = new HttpClient();

        private readonly ApplicationConfiguration _applicationConfiguration;
        private string _currentCodeVerifier;

        public Authenticator(ApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }

        public Uri CreateAuthorizeUrl()
        {
            // https://github.com/IdentityModel/IdentityModel/blob/master/src/CryptoRandom.cs
            _currentCodeVerifier = CryptoRandom.CreateUniqueId(64);
            using (var sha256 = (HashAlgorithm)CryptoConfig.CreateFromName("SHA-256"))
            {
                var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_currentCodeVerifier));
                // https://github.com/IdentityModel/IdentityModel/blob/master/src/Base64Url.cs
                var codeChallenge = Base64Url.Encode(challengeBytes);
                var codeFlowPkceAuthorizeUrl =
                    $"https://{_applicationConfiguration.Authority}/adfs/oauth2/authorize?" +
                    string.Join("&", new[]
                    {
                        $"response_type=code",
                        $"client_id={_applicationConfiguration.ClientId}",
                        $"scope={_applicationConfiguration.Scopes}",
                        $"redirect_uri={_applicationConfiguration.RedirectUri}",
                        $"code_challenge={codeChallenge}",
                        $"code_challenge_method=S256"
                    });
                return new Uri(codeFlowPkceAuthorizeUrl);
            }
        }

        public async Task<TokenResponse> PostAuthorizationCode(Uri codeFlowReturnUrl)
        {
            var code = CodeFromReturnUrl(codeFlowReturnUrl);

            var codeFlowPkceTokenUrl =
                $"https://{_applicationConfiguration.Authority}/adfs/oauth2/token";
            var body =
                new (string Key, string Value)[]
                    {
                        ("grant_type", "authorization_code"),
                        ("client_id", _applicationConfiguration.ClientId),
                        ("scope", _applicationConfiguration.Scopes),
                        ("redirect_uri", _applicationConfiguration.RedirectUri),
                        ("code", code),
                        ("code_verifier", _currentCodeVerifier),
                    }
                    .Select(pair => new KeyValuePair<string, string>(pair.Key, pair.Value));

            var message = new HttpRequestMessage(HttpMethod.Post, codeFlowPkceTokenUrl)
            {
                Content = new FormUrlEncodedContent(body)
            };
            var response = await HttpClient.SendAsync(message);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error during code exchange: Status {response.StatusCode}, {responseContent}");
            }
            return JsonConvert.DeserializeObject<TokenResponse>(responseContent);
        }

        private string CodeFromReturnUrl(Uri codeFlowReturnUrl)
        {
            var queryParameters = QueryHelpers.ParseNullableQuery(codeFlowReturnUrl.Query);
            return queryParameters.Single(pair => pair.Key.Equals("code", StringComparison.OrdinalIgnoreCase)).Value.Single();
        }

        public bool IsRedirectUrl(Uri candidateCodeFlowReturnUrl) => 
            candidateCodeFlowReturnUrl.ToString().StartsWith(_applicationConfiguration.RedirectUri, StringComparison.OrdinalIgnoreCase);
    }
}
