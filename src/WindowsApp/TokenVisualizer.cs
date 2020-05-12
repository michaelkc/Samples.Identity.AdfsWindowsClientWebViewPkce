using System;
using System.Text;

namespace App
{
    internal class TokenVisualizer
    {
        public string Visualize(TokenResponse tokenResponse)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Resource: {tokenResponse.Resource}, Scope: {tokenResponse.Scope}, TokenType: {tokenResponse.TokenType}");
            sb.AppendLine($"Id token parsed (expires {DateTime.Now.AddSeconds(tokenResponse.ExpiresIn):s} local time):");
            sb.AppendLine(JwtHelper.ToFormattedJson(tokenResponse.IdToken));
            sb.AppendLine($"Access token parsed (expires {DateTime.Now.AddSeconds(tokenResponse.ExpiresIn):s} local time):");
            sb.AppendLine(JwtHelper.ToFormattedJson(tokenResponse.AccessToken));
            sb.AppendLine($"Refresh token (expires {DateTime.Now.AddSeconds(tokenResponse.RefreshTokenExpiresIn):s} local time): ");
            sb.AppendLine(tokenResponse.RefreshToken);
            sb.AppendLine("Raw id token:");
            sb.AppendLine(tokenResponse.IdToken);
            sb.AppendLine("Raw access token:");
            sb.AppendLine(tokenResponse.AccessToken);
            return sb.ToString();
        }
    }
}