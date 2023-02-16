namespace Contracts.Common.Settings
{
    public class EmailSettings
    {
        public string ApiKey { get; set; } = string.Empty;

        public string FromAddress { get; set; } = string.Empty;

        public string FromName { get; set; } = string.Empty;

        public EmailSettings(string apiKey, string fromAddress, string fromName)
        {
            ApiKey = apiKey;
            FromAddress = fromAddress;
            FromName = fromName;
        }
    }
}
