namespace App
{
    internal class ApplicationConfiguration
    {
        // This should be externalized to a config file
        public string Authority { get; set; } = "si-idp.vfltest.dk";
        public string Scopes { get; set; } = "DEBUGagroidsamplepublicwindowsclientbackendapi";
        public string ClientId { get; set; } = "DEBUGagroidsamplepublicwindowsclient";
        public string RedirectUri { get; set; } = "urn:ietf:wg:oauth:2.0:oob";
    }
}
