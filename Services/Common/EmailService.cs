namespace Services.Common
{
    using System.Threading.Tasks;

    using Microsoft.Extensions.Options;

    using Contracts.Common.Models;
    using Contracts.Common.Results;
    using Contracts.Common.Infrastructure;

    using SendGrid;
    using SendGrid.Helpers.Mail;
    using Contracts.Common.Settings;

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<Result> SendEmail(Email email)
        {
            SendGridClient client = new(_emailSettings.ApiKey);

            string subject = email.Subject;
            string emailBody = email.Body;

            EmailAddress from = new()
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };
            EmailAddress to = new(email.To);

            SendGridMessage sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);

            Response response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted ||
                response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Result.OK();
            }

            return Result.FAILED();
        }
    }
}
