namespace Entities.EmployeeContext.ValueObjects
{
    using Contracts.Common.Results;
    using Contracts.Common.ResultTexts;
    using Contracts.Common.ValueObjects;

    public class EmployeeLastNameValue : ValueObject
    {
        private static readonly int MAX_LAST_NAME_LENGTH = 50;

        public static Result<EmployeeLastNameValue> Create(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return Result<EmployeeLastNameValue>.CONFLICT(ResultTexts.EMPLOYEE_LAST_NAME_CAN_NOT_BE_EMPTY);
            }

            if (lastName.Length > MAX_LAST_NAME_LENGTH)
            {
                return Result<EmployeeLastNameValue>.CONFLICT(ResultTexts.EMPLOYEE_LAST_NAME_CAN_NOT_EXCEED_MAX_LENGTH);
            }

            return Result<EmployeeLastNameValue>.OK(new EmployeeLastNameValue(lastName));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _lastName;
        }

        private EmployeeLastNameValue(string lastName)
        {
            _lastName = lastName;
        }

        private string _lastName;

        public string Value => _lastName;
    }
}
