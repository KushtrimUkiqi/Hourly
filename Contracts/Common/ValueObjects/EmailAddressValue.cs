namespace Contracts.Common.ValueObjects
{
    using System.Net.Mail;
    using System.Collections.Generic;

    using Contracts.Common.Results;
    using Contracts.Common.ResultTexts;

    public class EmailAddressValue : ValueObject
    {
        public static Result<EmailAddressValue> Create(string emailAddress)
        {
            MailAddress.TryCreate(emailAddress, out MailAddress? emailAddressValue);

            if (emailAddressValue == null) 
            {
                return Result<EmailAddressValue>.FAILED(ResultTexts.EMAIL_ADDRESS_INVALID);
            }

            return Result<EmailAddressValue>.OK(new EmailAddressValue(emailAddressValue.ToString()));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _emailAddress;
        }

        private EmailAddressValue(string emailAddress) 
        {
            _emailAddress = emailAddress;
        }


        private readonly string _emailAddress;

        public string Value => _emailAddress;
    }
}
