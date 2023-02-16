namespace Contracts.Common.Settings
{
    public class MessageBrokerSettings
    {
        /// <summary>
        /// Message broker host 
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        public MessageBrokerSettings()
        {

        }

        public MessageBrokerSettings(string host, string userName, string password)
        {
            Host = host;
            Username = userName;
            Password = password;
        }
    }
}
