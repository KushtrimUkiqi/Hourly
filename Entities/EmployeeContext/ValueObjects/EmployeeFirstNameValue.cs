namespace Entities.EmployeeContext.ValueObjects
{
    using Contracts.Common.Results;
    using Contracts.Common.ResultTexts;
    using Contracts.Common.ValueObjects;
    using System.Collections.Generic;

    public class EmployeeFirstNameValue : ValueObject
    { 
        private static readonly int MAX_FIRST_NAME_LENGTH = 50;

        public static Result<EmployeeFirstNameValue> Create(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                return Result<EmployeeFirstNameValue>.CONFLICT(ResultTexts.EMPLOYEE_FIRST_NAME_CAN_NOT_BE_EMPTY);
            }

            if (firstName.Length > MAX_FIRST_NAME_LENGTH)
            {
                return Result<EmployeeFirstNameValue>.CONFLICT(ResultTexts.EMPLOYEE_FIRST_NAME_CAN_NOT_EXCEED_MAX_LENGTH);
            }

            return Result<EmployeeFirstNameValue>.OK(new EmployeeFirstNameValue(firstName));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _firstName;
        }

        private EmployeeFirstNameValue(string firstName)
        {
            _firstName = firstName;
        }

        private string _firstName;

        public string Value => _firstName;
    }
}
