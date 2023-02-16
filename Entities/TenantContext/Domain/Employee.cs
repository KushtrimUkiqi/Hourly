namespace Entities.TenantContext.Domain
{
    using Contracts.Common.Results;
    using Contracts.Common.DomainEntities;

    public class Employee : DomainEntity
    {
        public Guid Uid { get; private set; }

        /// <summary>
        /// Creates domain object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uid"></param>
        /// <param name="createdOn"></param>
        /// <param name="deletedOn"></param>
        /// <returns></returns>
        public static Result<Employee> CreateFromStorage(
            int id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn)
        {
            return Result<Employee>.OK(new Employee
            {
                Id = id,
                CreatedOn = createdOn,
                DeletedOn = deletedOn,
                Uid = uid
            });
        }
    }
}
