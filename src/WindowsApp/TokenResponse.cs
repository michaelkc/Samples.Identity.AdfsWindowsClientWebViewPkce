using Newtonsoft.Json;

namespace App
{
    internal class TokenResponse
    {
        [JsonProperty(propertyName: "access_token")]
        public string AccessToken { get; set; }
        [JsonProperty(propertyName: "token_type")]
        public string TokenType { get; set; }
        [JsonProperty(propertyName: "expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty(propertyName: "resource")]
        public string Resource { get; set; }
        [JsonProperty(propertyName: "refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty(propertyName: "refresh_token_expires_in")]
        public int RefreshTokenExpiresIn { get; set; }
        [JsonProperty(propertyName: "scope")]
        public string Scope { get; set; }
        [JsonProperty(propertyName: "id_token")]
        public string IdToken { get; set; }
    }
}
