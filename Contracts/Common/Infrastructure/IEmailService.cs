namespace Contracts.Common.Infrastructure
{
    using Contracts.Common.Models;
    using Contracts.Common.Results;

    public interface IEmailService
    {
        Task<Result> SendEmail(Email email);
    }
}
