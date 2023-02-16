namespace Entities.EmployeeContext.Domain
{
    using Contracts.Common.Results;
    using Contracts.Common.ValueObjects;
    using Entities.EmployeeContext.ValueObjects;

    public partial class Employee
    {
        /// <summary>
        /// Domain object created from the db
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uid"></param>
        /// <param name="createdOn"></param>
        /// <param name="deletedOn"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="position"></param>
        /// <param name="status"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static Result<Employee> CreateFromStorage (
            int id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string position,
            int tenantId,
            string status)
        {
            Result<EmployeeFirstNameValue> employeeFirstNameValueResult = EmployeeFirstNameValue.Create(firstName);
            Result<EmployeeLastNameValue> employeeLastNameValueResult = EmployeeLastNameValue.Create(lastName);
            Result<EmailAddressValue> emailAddressValueResult = EmailAddressValue.Create(email);
            Result<PhoneNumberValue> phoneNumberValueResult = PhoneNumberValue.Create(phoneNumber);


            Result resultError = new List<Result> { employeeFirstNameValueResult, employeeLastNameValueResult, emailAddressValueResult, phoneNumberValueResult }.ReturnResult();
            
            if (resultError.IsFailure)
            {
                return Result<Employee>.FROM_ERROR(resultError);
            }

            return Result<Employee>.OK(
                new Employee
                {
                    Id = id,
                    Uid = uid,
                    CreatedOn = createdOn,
                    DeletedOn = deletedOn,
                    FirstName = employeeFirstNameValueResult.Value,
                    LastName = employeeLastNameValueResult.Value,
                    EmailAddress = emailAddressValueResult.Value,
                    PhoneNumber = phoneNumberValueResult.Value,
                    EmployeePosition = position,
                    Status = status,
                    TenantId = tenantId
                });
        }

        /// <summary>
        /// Domain object created from the creation flow
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Result<Employee> Create(
            int tenantId,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string position,
            string status = "NotInvited")
        {
            Result<EmployeeFirstNameValue> employeeFirstNameValueResult = EmployeeFirstNameValue.Create(firstName);
            Result<EmployeeLastNameValue> employeeLastNameValueResult = EmployeeLastNameValue.Create(lastName);
            Result<EmailAddressValue> emailAddressValueResult = EmailAddressValue.Create(email);
            Result<PhoneNumberValue> phoneNumberValueResult = PhoneNumberValue.Create(phoneNumber);


            Result resultError = new List<Result> { employeeFirstNameValueResult, employeeLastNameValueResult, emailAddressValueResult, phoneNumberValueResult }.ReturnResult();

            if (resultError.IsFailure)
            {
                return Result<Employee>.FROM_ERROR(resultError);
            }

            return Result<Employee>.OK(
                new Employee
                {
                    Uid = Guid.NewGuid(),
                    CreatedOn = DateTime.UtcNow,
                    DeletedOn = null,
                    FirstName = employeeFirstNameValueResult.Value,
                    LastName = employeeLastNameValueResult.Value,
                    EmailAddress = emailAddressValueResult.Value,
                    PhoneNumber = phoneNumberValueResult.Value,
                    EmployeePosition = position,
                    Status = status,
                    TenantId = tenantId
                });
        }


        public Result Invite()
        {
            if(Status == "IsInvited")
            {
                return Result.FAILED();
            }

            Status = "IsInvited";

            return Result.OK();
        }

        /// <summary>
        /// Marks the employee as deleted
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public Result MarkAsDeleted(DateTime dateTime)
        {
            DeletedOn = dateTime;

            return Result.OK();
        }
    }

}
