namespace Contracts.Common.ValueObjects
{
    using System.Collections.Generic;

    using Contracts.Common.Results;
    using Contracts.Common.ResultTexts;

    public class PhoneNumberValue : ValueObject
    {
        public static Result<PhoneNumberValue> Create(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return Result<PhoneNumberValue>.FAILED(ResultTexts.PHONE_NUMBER_INVALID);
            }

            return Result<PhoneNumberValue>.OK(new PhoneNumberValue(phoneNumber));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _phoneNumber;
        }

        private PhoneNumberValue(string phoneNumber)
        {   
            _phoneNumber = phoneNumber;
        }


        private readonly string _phoneNumber;

        public string Value => _phoneNumber;
    }
}
