using System;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace App
{
    internal static class JwtHelper
    {
        public static string ToFormattedJson(string jwt)
        {
            var parts = (jwt ?? string.Empty).Split('.');
            if (parts.Length != 3)
            {
                return string.Empty;
            }
            var encodedHeader = parts[0];
            var encodedBody = parts[1];
            var signature = parts[2];

            var header = Prettify(Encoding.ASCII.GetString(WebEncoders.Base64UrlDecode(encodedHeader)));
            var body = Prettify(Encoding.ASCII.GetString(WebEncoders.Base64UrlDecode(encodedBody)));
            return $"{header}{Environment.NewLine}{body}{Environment.NewLine}{signature}";
        }

        private static string Prettify(string json)
        {
            var parsedJson = JToken.Parse(json);
            return parsedJson.ToString(Formatting.Indented);
        }
    }
}